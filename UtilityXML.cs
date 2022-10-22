using System.Xml.Linq;

internal class UtilityXML
{
    private static XElement loadElemet(string path)
    {
        try
        {
            return XElement.Load(path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Can not find " + path + "\n\n" + ex.ToString(), "ERROR");
            return null;
        }
    }

    public static Array loadEquiClass()
    {
        XElement xElement = loadElemet("Data\\Equipments.xml");
        IEnumerable<XName> source = (from e in xElement.Descendants()
                                     where e.Name != "item"
                                     select e.Name).Distinct();
        return source.ToArray();
    }

    public static Array loadEquipTypes(string eleName)
    {
        XElement xElement = loadElemet("Data\\Equipments.xml");
        IEnumerable<string> source = (from c in xElement.Elements(eleName).Elements("item")
                                      select c.Attribute("type").Value).Distinct();
        return source.ToArray();
    }

    public static List<object> loadEquips(string tagName, string attribute)
    {
        try
        {
            XElement xElement = loadElemet("Data\\Equipments.xml");
            var collection = from c in xElement.Elements(tagName).Elements("item")
                             where c.Attribute("type").Value == attribute
                             select new
                             {
                                 Name = c.Attribute("name").Value,
                                 ID = c.Attribute("id").Value
                             };
            return new List<object>(collection);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Error-XML");
            return null;
        }
    }

    public static List<object> loadCraftSlotOption(string file, string tagName)
    {
        try
        {
            XElement xElement = loadElemet("Data\\" + file);
            var collection = from c in xElement.Elements(tagName).Elements("msg")
                             select new
                             {
                                 Cont = c.Attribute("cont").Value,
                                 ID = c.Attribute("id").Value
                             };
            return new List<object>(collection);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Error-XML");
            return null;
        }
    }

    public static Array loadItemClass()
    {
        XElement xElement = loadElemet("Data\\Items.xml");
        IEnumerable<XName> source = (from e in xElement.Descendants()
                                     where e.Name != "msg" && e.Name != "Description"
                                     select e.Name).Distinct();
        return source.ToArray();
    }

    public static Array loadItemTypes(string eleName)
    {
        XElement xElement = loadElemet("Data\\Items.xml");
        IEnumerable<string> source = (from c in xElement.Elements(eleName).Elements("msg")
                                      select c.Attribute("type").Value).Distinct();
        return source.ToArray();
    }

    public static List<object> loadItems(string eleName, string attribute)
    {
        XElement xElement = loadElemet("Data\\Items.xml");
        var collection = from c in xElement.Elements(eleName).Elements("msg")
                         where c.Attribute("type").Value == attribute && !c.Attribute("cont").Value.Equals("")
                         select new
                         {
                             ID = c.Attribute("id").Value,
                             Cont = c.Attribute("cont").Value
                         };
        return new List<object>(collection);
    }

    public static string loadItemOpt(string id, int classItem, int index)
    {
        XElement xElement = loadElemet("Data\\Items.xml");
        IEnumerable<string> source = new string[] { };
        if (classItem == 5)
        {
            source = from c in xElement.Elements("Formula-Card").Elements("msg")
                     where c.Attribute("index").Value == (index + 1).ToString()
                     select c.Attribute("option").Value;
        }
        else
        {
            source = from c in xElement.Elements("Dungeon-Entry-Items").Elements("msg")
                     where c.Attribute("id").Value == id
                     select c.Attribute("option").Value;
        }
        return source.ToArray().GetValue(0).ToString();
    }

    public static string loadItemDesc(string id)
    {
        XElement xElement = loadElemet("Data\\Items.xml");
        IEnumerable<string> source = from c in xElement.Elements("Description").Elements("msg")
                                     where c.Attribute("id").Value == id
                                     select c.Attribute("cont").Value;
        return source.ToArray().GetValue(0).ToString();
    }

    public static List<object> loadPetTypes()
    {
        XElement xElement = loadElemet("Data\\Pets.xml");
        var collection = from c in xElement.Elements("Pets").Elements("msg")
                         select new
                         {
                             ID = c.Attribute("id").Value,
                             Cont = c.Attribute("cont").Value
                         };
        return new List<object>(collection);
    }

    public static List<object> loadPetOpt()
    {
        XElement xElement = loadElemet("Data\\Pets.xml");
        var collection = from c in xElement.Elements("Opt").Elements("petOpt")
                         select new
                         {
                             Opt = c.Attribute("option").Value,
                             Name = c.Attribute("name").Value
                         };
        return new List<object>(collection);
    }

    public static string getPetName(string id)
    {
        XElement xElement = loadElemet("Data\\Pets.xml");
        IEnumerable<string> enumerable = from c in xElement.Elements("Pets").Elements("msg")
                                         where c.Attribute("id").Value == id
                                         select c.Attribute("cont").Value;
        if (enumerable == null)
        {
            return "";
        }
        return (enumerable.ToArray().Count() == 0) ? "" : enumerable.ToArray().GetValue(0).ToString();
    }

    public static List<object> getListDurationID()
    {
        XElement xElement = loadElemet("Data\\DurationID.xml");
        var collection = from c in xElement.Elements("dur")
                         select new
                         {
                             ID = c.Attribute("id").Value,
                             Cont = c.Attribute("cont").Value + "  (" + c.Attribute("id").Value + ") "
                         };
        return new List<object>(collection);
    }

    public static List<object> getListTitle()
    {
        XElement xElement = loadElemet("Data\\Title.xml");
        var collection = from c in xElement.Elements("msg")
                         select new
                         {
                             ID = c.Attribute("id").Value,
                             Cont = c.Attribute("id").Value + " | " + c.Attribute("cont").Value
                         };
        return new List<object>(collection);
    }

    public static string getSkillName(string id)
    {
        XElement xElement = loadElemet("Data\\Skill.xml");
        IEnumerable<string> source = from c in xElement.Elements("Description").Elements("msg")
                                     where c.Attribute("id").Value == id
                                     select c.Attribute("cont").Value;
        return source.ToArray().GetValue(0).ToString();
    }

    public static string getSkillDescription(string id)
    {
        XElement xElement = loadElemet("Data\\Skill.xml");
        IEnumerable<string> source = from c in xElement.Elements("Description").Elements("msg")
                                     where c.Attribute("id").Value == id
                                     select c.Attribute("cont").Value;
        return source.ToArray().GetValue(0).ToString();
    }
}
