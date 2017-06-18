using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data;
using System.ComponentModel;

namespace ClassesSchedule.ViewModel
{

        public class WATColumn
        {
            [JsonProperty("index")]
            public int Index { get; set; }
            [JsonProperty("type")]
            public string Type { get; set; }
            [JsonProperty("friendly")]
            public string Friendly { get; set; }
            /// <summary>
            /// this could be string or false.
            /// string means automatic filter in the grid on the value.
            /// false means no filter on the column
            /// </summary>
            [JsonProperty("filter")]
            public object IsFilter { get; set; }

            [JsonProperty("format")]
            public string Format { get; set; }
            [JsonProperty("sorting")]
            public bool Sorting { get; set; }

            [JsonProperty("unique")]
            public bool IsUnique { get; set; }

            [JsonProperty("dateFormat")]
            public string DateFormat { get; set; }

            //index: 1, //The order this column should appear in the table
            //type: "number", //The type. Possible are string, number, bool, date(in milliseconds).
            //friendly: "<span class='glyphicon glyphicon-user'></span>",  //Name that will be used in header. Can also be any html as shown here.
            //format: "<a href='#' target='_blank'>{0}</a>",  //Used to format the data anything you want. Use {0} as placeholder for the actual data.
            //unique: true,  //This is required if you want checkable rows, databinding or to use the rowClicked callback. Be certain the values are really unique or weird things will happen.
            //sortOrder: "asc", //Data will initially be sorted by this column. Possible are "asc" or "desc"
            //tooltip: "This column has an initial filter", //Show some additional info about column
            //filter: "1..400" //Set initial filter.

            [JsonProperty("hidden")]
            public bool IsHidden { get; set; }


            [JsonProperty("dateUTC")]
            public bool DateUTC { get; set; }

            public WATColumn()
            {
                IsFilter = null;
                Sorting = true;
                // set UTC date format as default resulting no conversion in WaTable engine
                // it means the milliseconds value in the row (coming from the controller) has the value in local time already (using the LIMTSession.TimeZoneMinutes)
                DateUTC = true;
            }
        }

        public class WATableModelBase<T>
        {
            [JsonProperty("cols")]
            public Dictionary<string, WATColumn> Columns { get; set; }

            /// <summary>
            /// makes the Columns dictionary. type gets the type of the property. friendly gets the Display(Name) value if available, otherwise property name
            /// </summary>
            /// <param name="propnames">array of properties in T. they have to exists in the T</param>
            public void AddColumns(string[] propnames)
            {

                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                Dictionary<string, WATColumn> coldef = new Dictionary<string, WATColumn>();
                foreach (string propname in propnames)
                {
                    // check if the prop is available in the underlying type
                    var pd = properties.Find(propname, false);
                    if (pd == null)
                    {
                        throw new ApplicationException(string.Format("Property is not found: {0}", propname));
                    }
                    string type = pd.PropertyType.Name.ToLower();
                    if (type == "int64" && pd.Name.EndsWith("MS"))
                    {
                        // watable needs long datatype having the value as milliseconds since epoch
                        // assume the name of such attributes ends with MS
                        type = "date";
                    }
                    else if (type == "int")
                    {
                        type = "number";
                    }
                    else if (type == "boolean")
                    {
                        type = "bool";
                    }
                    string dispname = pd.Name;
                    var dispattr = pd.Attributes.Cast<Attribute>().FirstOrDefault(a => a.GetType() == typeof(System.ComponentModel.DataAnnotations.DisplayAttribute));
                    if (dispattr != null)
                    {
                        dispname = ((System.ComponentModel.DataAnnotations.DisplayAttribute)dispattr).Name;
                    }

                    coldef.Add(propname, new WATColumn { Index = Array.IndexOf(propnames, propname) + 1, Type = type, Friendly = dispname });
                }

                Columns = coldef;
            }

            public void AddAllProperties(string[] exclude = null)
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                Dictionary<string, WATColumn> coldef = new Dictionary<string, WATColumn>();
                int idx = 1;
                foreach (PropertyDescriptor pd in properties)
                {
                    if (exclude != null && exclude.Contains(pd.Name))
                    {
                        // skip the excluded properties
                        continue;
                    }
                    string dispname = pd.Name;

                    string type = pd.PropertyType.Name.ToLower();
                    if (type == "int64" && pd.Name.EndsWith("MS"))
                    {
                        // watable needs long datatype having the value as milliseconds since epoch
                        // assume the name of such attributes ends with MS
                        type = "date";
                    }
                    else if (type == "int")
                    {
                        type = "number";
                    }
                    else if (type == "boolean")
                    {
                        type = "bool";
                    }
                    var dispattr = pd.Attributes.Cast<Attribute>().FirstOrDefault(a => a.GetType() == typeof(System.ComponentModel.DataAnnotations.DisplayAttribute));
                    if (dispattr != null)
                    {
                        dispname = ((System.ComponentModel.DataAnnotations.DisplayAttribute)dispattr).Name;
                    }

                    coldef.Add(pd.Name, new WATColumn { Index = idx++, Type = type, Friendly = dispname });
                }

                Columns = coldef;

            }

        }

        public class WATableModel<T> : WATableModelBase<T>
        {
            [JsonProperty("rows")]
            public List<T> Rows { get; set; }

        }

        public class WATableModelDT<T> : WATableModelBase<T>
        {
            [JsonProperty("rows")]
            public IEnumerable<Dictionary<string, object>> Rows { get; set; }
            private Dictionary<string, WATColumn> _ColDef;

            public WATableModelDT(DataTable dt, List<string> datecols = null, List<string> timecols = null)
            {
                if (datecols == null)
                {
                    datecols = new List<string>();
                }
                if (timecols == null)
                {
                    timecols = new List<string>();
                }
                InitFromDT(dt, datecols, timecols);
            }

            private void InitFromDT(DataTable dt, List<string> datecols, List<string> timecols)
            {
                // build columns
                int idx = 1;

                _ColDef = new Dictionary<string, WATColumn>();
                foreach (DataColumn col in dt.Columns)
                {
                    string dispname = col.ColumnName;
                    string dateformat = null;

                    string type = col.DataType.Name.ToLower();
                    if (type == "datetime")
                    {
                        // watable needs long datatype having the value as milliseconds since epoch
                        type = "date";
                        if (datecols.Contains(col.ColumnName))
                        {
                            dateformat = System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        }
                        if (timecols.Contains(col.ColumnName))
                        {
                            dateformat = System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortTimePattern;
                        }
                    }
                    else if (type == "int")
                    {
                        type = "number";
                    }
                    else if (type == "boolean")
                    {
                        type = "bool";
                    }

                    _ColDef.Add(col.ColumnName, new WATColumn { Index = idx++, Type = type, Friendly = dispname, DateFormat = dateformat });

                }
                Columns = _ColDef;

                // build up rows
                IEnumerable<Dictionary<string, object>> result = dt.Rows.Cast<DataRow>()
                      .Select(DTRowSelector);

                Rows = result;

            }

            private Dictionary<string, object> DTRowSelector(DataRow dr)
            {
                Dictionary<string, object> ret = new Dictionary<string, object>();
                foreach (KeyValuePair<string, WATColumn> col in _ColDef)
                {
                    object value = dr[col.Key];
                    if (col.Value.Type == "date")
                    {
                        // change this to long, converting to milliseconds
                        if (value != DBNull.Value)
                        {
                         //   value = (long)((DateTime)value - BusinessLogic.EPOCH).TotalMilliseconds;
                        }
                        else
                        {
                            value = 0;
                        }

                    }
                    ret.Add(col.Key, value);
                }

                return ret;
            }
        }
    }