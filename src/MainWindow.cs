using System;
using Gtk;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MonoDevelop.Projects.Utility;
namespace BibliographyMaker{

public partial class MainWindow: Gtk.Window
{	

	#region stringvarss
			public static string[] author = new string[400];
			public static string[] fname = new string[20];
			public static string database = "/usr/lib/BibliographyMaker/database.xml";
	public static StringBuilder bib = new StringBuilder();
			public static string entryval;
			public static string nameval;
			public static string typeval;
			public static string dayval;
			public static string monthval;
			public static string yearval;
			public static string titleval;
			public static string corpauthval;
			public static string pubval;
			public static string cityval;
			public static string countryval;
			public static string journalval;
			public static string articleval;
			public static string volumeval;
			public static string issueval;
			public static string bibnameval;
			public static string issnval;
			public static string isbnval;
			public static string locval;
			public static string doival;
			public static string urlval;
			public static string mediumval;
			public static string editionval;
			public static string institutionval;
			public static string pubtypeval;
			public static string chapterval;
			public static string pagesval;
			public static string seriesval;
			public static string orgval;
			public static string universityval;
			public static string editorval;
			public static string translatorval;
			public static string etceteraval;
			public static string annotationval;
	public static string directorval;
	public static string accessyearval;
			public static string accessdayval;
			public static string accessmonthval;
	public static string runtimeval;
			public static string output;

			public static string daymake;
			public static string monthmake;
			public static string yearmake;
			public static string titlemake;
			public static string corpauthmake;
			public static string pubmake;
			public static string citymake;
			public static string countrymake;
	public static string journalmake;
			public static string articlemake;
			public static string volumemake;
			public static string issuemake;
			public static string issnmake;
			public static string isbnmake;
			public static string locmake;
			public static string doimake;
			public static string urlmake;
			public static string mediummake;
			public static string editionmake;
			public static string institutionmake;
			public static string pubtypemake;
			public static string chaptermake;
			public static string pagesmake;
			public static string seriesmake;
			public static string orgmake;
			public static string universitymake;
			public static string editormake;
			public static string translatormake;
			public static string etceteramake;
			public static string annotationmake;
			public static string directormake;
			public static string accessyearmake;
			public static string accessdaymake;
			public static string accessmonthmake;
	public static string runtimemake;


			public static string styleval;
			public static string typemake;
			public static string formatval;
			public static string entrymake;
			public static int numofentries;
			
			
			
#endregion

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		listentries();
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}	
	protected void submitEvent (object sender, EventArgs e)
	{
		#region setinvars
			bibnameval = bibname.Text.ToString();
			typeval = type.Active.ToString();
			nameval = name.Text.ToString();
			dayval = day.Text.ToString();
			monthval = month.Text.ToString();
			yearval = year.Text.ToString();
			titleval = title.Text.ToString();
			corpauthval = corpauth.Text.ToString();
			pubval = pub.Text.ToString();
			cityval = city.Text.ToString();
			countryval = country.Text.ToString();
			journalval = journal.Text.ToString();
			articleval = article.Text.ToString();
			volumeval = volume.Text.ToString();
			issueval = issue.Text.ToString();
			issnval = issn.Text.ToString();
			isbnval = isbn.Text.ToString();
			locval = loc.Text.ToString();
			doival = doi.Text.ToString();
			urlval = url.Text.ToString();
			mediumval = medium.Text.ToString();
			editionval = edition.Text.ToString();
			institutionval = institution.Text.ToString();
			pubtypeval = pubtype.Text.ToString();
			chapterval = chapter.Text.ToString();
			pagesval = pages.Text.ToString();
			seriesval = series.Text.ToString();
			orgval = org.Text.ToString();
			universityval = university.Text.ToString();
			editorval = editor.Text.ToString();
			translatorval = translator.Text.ToString();
			etceteraval = etcetera.Text.ToString();
		directorval = director.Text.ToString();
		accessdayval = accessday.Text.ToString();
		accessmonthval = accessmonth.Text.ToString();
		accessyearval = accessyear.Text.ToString();
			annotationval = annotation.Buffer.Text.ToString();
		runtimeval = runtime.Text.ToString();
		#endregion

		writex();
		update();
	}

	protected void makeEvent (object sender, EventArgs e)
	{
		#region setmakevars
		formatval = combobox2.Active.ToString ();
		entrymake = combobox3.Active.ToString ();
		styleval = combobox1.Active.ToString ();
		string[] firstname = new string[20];
		string[] middlename = new string[20];
		string[] lastname = new string[20];
		string[] element = new string[36];
		element [0] = "type";
		element [2] = "title";
		element [3] = "day";
		element [4] = "month";
		element [5] = "year";
		element [6] = "corpauth";
		element [7] = "publisher";
		element [8] = "city";
		element [9] = "country";
		element [10] = "journal";
		element [11] = "article";
		element [12] = "volume";
		element [13] = "issue";
		element [14] = "issn";
		element [15] = "isbn";
		element [16] = "loc";
		element [17] = "doi";
		element [18] = "url";
		element [19] = "medium";
		element [20] = "edition";
		element [21] = "institution";
		element [22] = "publicationtype";
		element [23] = "chapter";
		element [24] = "pages";
		element [25] = "series";
		element [26] = "org";
		element [27] = "university";
		element [28] = "editor";
		element [29] = "translator";
		element [30] = "etcetera";
		element [31] = "director";
		element [32] = "accessday";
		element [33] = "accessmonth";
		element [34] = "accessyear";
		element [35] = "runtime";
		element [1] = "annotation";
		string[] data = new string[36];
		#endregion	
		int i = 0;


		foreach (string a in element) {
			XmlDocument d = new XmlDocument ();
			d.Load (database);
			XmlNodeList n = d.GetElementsByTagName (a + entrymake);
			if (n != null) {
				foreach (XmlNode curr in n) {
					data [i] = (curr.InnerText);
				}
			}
			++i;
		}


		var authors = 0;
		using (var reader = XmlReader.Create(database)) {
			while (reader.Read()) {
				if (reader.NodeType == XmlNodeType.Element && 
					reader.Name == "author" + entrymake + "-" + authors) {
					authors++;
				}
			}
		}
		int m = 0;
		while (m <= authors) {
			XmlDocument d = new XmlDocument();
			d.Load(database);
			XmlNodeList n = d.GetElementsByTagName("firstname" + entrymake + "-" + m.ToString());
			if(n != null) {
				foreach(XmlNode curr in n) {
					firstname[m] = (curr.InnerText);
				}
			}
			XmlNodeList c = d.GetElementsByTagName("middlename" + entrymake + "-" + m);
			if(c != null) {
				foreach(XmlNode curr in c) {
					middlename[m] = (curr.InnerText);
				}
			}
			XmlNodeList j = d.GetElementsByTagName("lastname" + entrymake + "-" + m);
			if(j != null) {
				foreach(XmlNode curr in j) {
					lastname[m] = (curr.InnerText);
				}
			}
			++m;
	}
				formattoutput(data,firstname,lastname,middlename, authors);
				outputentry ();
	}
		
	public void update()
	{
		string data;
		using (StreamReader reader= new StreamReader(database)) {
			data = reader.ReadToEnd().ToString();
					}
		 dataview.Buffer.Text = data;
	}
	public void auth(int ids)
	{
			string[] authorl = MainWindow.nameval.Split(';');	
			int i = 0;
			foreach (string n in authorl) {
				author[i] = n;
				using (StreamWriter writer = new StreamWriter(database, true)) {
					writer.WriteLine("<author" + ids + "-" + i + ">");
					writer.Close();
					}
				int ne = 0;
				string prefix = "first";
				string[] authorfs = author[i].Split (',');
				foreach (string m in authorfs){
					if (ne == 0){prefix = "first";}
					else if (ne == 1){prefix = "last";}
					else if (ne == 2){prefix = "middle";}
					using (StreamWriter writer = new StreamWriter(database, true)) {
						writer.Write("<" + prefix + "name" + ids + "-" + i + ">" );
						writer.Write(m);
						writer.WriteLine("</" + prefix + "name" + ids + "-" + i + ">");
						writer.Close();
							++ne;
					}
				}
				using (StreamWriter writer = new StreamWriter(database, true)) {
					writer.WriteLine("</author" + ids + "-" + i + ">");
					writer.Close();
					}
				++i;
			} 
		}
	public void writex()
		{

			var nodeCount = 0;
			using (var reader = XmlReader.Create(database)) {
				while (reader.Read()) {
					if (reader.NodeType == XmlNodeType.Element && 
						reader.Name == "entry") {
						nodeCount++;
					}
				}
			}

		 var id = nodeCount + 1;

			XElement entries =
       				new XElement ("entry",
				              new XAttribute ("id", id),
				              new XAttribute ("name", bibnameval),
				        new XElement ("type" + id, typeval),
          				new XElement ("title" + id, titleval), 
          				new XElement ("date",
                			new XElement ("day" + id, dayval),
				            new XElement ("month" + id, monthval),
				            new XElement ("year" + id, yearval)
			),
				        new XElement ("corpauth" + id, corpauthval),
				        new XElement ("publisher" + id, pubval),
				        new XElement ("city" + id, cityval),
				        new XElement ("country" + id, countryval),
				        new XElement ("journal" + id, journalval),
				        new XElement ("article" + id, articleval),
				        new XElement ("volume" + id, volumeval),
				        new XElement ("issue" + id, issueval),

				       	new XElement ("issn"+ id, issnval),
						new XElement ("isbn" + id, isbnval),
						new XElement ("librarycongress" + id, locval),
						new XElement ("doi" + id, doival),
						new XElement ("url" + id, urlval),
						new XElement ("medium" + id, mediumval),
						new XElement ("edition" + id, editionval),
						new XElement ("institution" + id, institutionval),
						new XElement ("publicationtype" + id, pubtypeval),
						new XElement ("chapter" + id, chapterval),
						new XElement ("pages" + id, pagesval),
						new XElement ("series" + id, seriesval),
						new XElement ("organization" + id, orgval),
						new XElement ("university" + id, universityval),
						new XElement ("editor" + id, editorval),
						new XElement ("translator" + id, translatorval),
						new XElement ("etcetera" + id, etceteraval),
			            new XElement ("director" + id, directorval),
			            new XElement ("accessday" + id, accessdayval),
			              new XElement ("accessmonth" + id, accessmonthval),
			              new XElement ("accessyear" + id, accessyearval),
			              new XElement ("runtime" + id, runtimeval),
				        new XElement ("annotation" + id, annotationval)
			);

			List<string> lines = new List<string> (File.ReadAllLines (database));
			int lineIndex = lines.FindIndex (line => line.StartsWith ("</ENTRIES>"));
			if (lineIndex != -1) {
				lines [lineIndex] = "";
				File.WriteAllLines (database, lines);
			}

			using (StreamWriter writer = new StreamWriter(database, true)) {
				writer.WriteLine ("<source>");
				writer.WriteLine (entries);
			}

			auth(id);
			using (StreamWriter writer = new StreamWriter(database, true)) {
				writer.WriteLine("</source>");
				writer.WriteLine("</ENTRIES>");
				writer.Close();
			}
			}

	public void listentries ()
	{
		var nodeCount = 0;
		using (var reader = XmlReader.Create(database)) {
			while (reader.Read()) {
				if (reader.NodeType == XmlNodeType.Element && 
					reader.Name == "entry") {
					nodeCount++;
				}
			}
		}
		numofentries = nodeCount;
		int i = 1;
		var node = "";
		while (i <= numofentries && i >= 0)
		{

			XmlDocument d = new XmlDocument();
			d.Load(database);
			XmlNodeList n = d.GetElementsByTagName("title" + i);
			if(n != null) {
				foreach(XmlNode curr in n) {
					node = (curr.InnerText);
				}

				combobox3.RemoveText(i);
				combobox3.InsertText (i,node.ToString());
			}
			i++;
		}

	}

	public void formattoutput (string[] data,
	                           string[] firstname,
	                           string[] lastname, 
	                           string[] middlename, 
	                           int authors)	{
#region data
typemake = data [0];
titlemake = data [2];
daymake = data [3];
monthmake = data [4];
yearmake = data [5];
corpauthmake = data [6];
pubmake = data [7];
citymake = data [8];
countrymake = data [9];
journalmake = data [10];
articlemake = data [11];
volumemake = data [12];
issuemake = data [13];
issnmake = data [14];
isbnmake = data [15];
locmake = data [16];
doimake = data [17];
urlmake = data [18];
mediummake = data [19];
editionmake = data [20];
institutionmake = data [21];
pubtypemake = data [22];
chaptermake = data [23];
pagesmake = data [24];
seriesmake = data [25];
orgmake = data [26];
universitymake = data [27];
editormake = data [28];
translatormake = data [29];
etceteramake = data [30];
directormake = data [31];
accessdaymake = data [32];
accessmonthmake = data [33];
accessyearmake = data [34];
		runtimemake = data [35];
annotationmake = data [1];
#endregion

#region stylevars
				var style = "";
				if (styleval == "0") {
					requiredField ();
				}
				if (styleval == "1") {
					style = "Chicago";
				}
				if (styleval == "2") {
					style = "APA";
				}
				if (styleval == "3") {
					style = "MLA";
				}
#endregion

#region formvars
				var format = "none";
				if (formatval == "0") {
					requiredField ();
				}
				if (formatval == "1") {
					format = "Bibliography";
				}
				if (formatval == "2") {
					format = "InTextCitation";
				}
				if (formatval == "3") {
					format = "Footnote";
				}
				if (formatval == "4") {
					format = "EndNote";
				}
				if (formatval == "5") {
					format = "WorksCited";
				}
#endregion

#region typevars
				var type = "none";
				if (typemake == "0") {
					requiredField ();
				}
				if (typemake == "1") {
					type = "Book";
				}
				if (typemake == "2") {
					type = "PrintJournal";
				}
				if (typemake == "3") {
					type = "BookReview";
				}
				if (typemake == "4") {
					type = "Magazine";
				}
				if (typemake == "5") {
					type = "DailyNewspaper";
				}
				if (typemake == "6") {
					type = "EditorialinNewspaper";
				}
				if (typemake == "7") {
					type = "LetterToEditor";
				}
				if (typemake == "8") {
					type = "EntireWebsite";
				}
				if (typemake == "9") {
					type = "WebPage";
				}

				if (typemake == "10") {
					type = "OnlineJournal";
				}
				if (typemake == "11") {
					type = "OnlineBook";
				}
				if (typemake == "12") {
					type = "OnlineMag";
				}
				if (typemake == "13") {
					type = "EntireBlog";
				}
				if (typemake == "14") {
					type = "ResponseinBlog";
				}
				if (typemake == "15") {
					type = "PortionOnlineBook";
				}
				if (typemake == "16") {
					type = "CD-Rom";
				}
				if (typemake == "17") {
					type = "E-Mail";
				}
				if (typemake == "18") {
					type = "Video/Film";
				}
				if (typemake == "19") {
					type = "Podcast/Youtube";
				}
				if (typemake == "20") {
					type = "Lecture/PublicAddress";
				}
				if (typemake == "21") {
					type = "Thesis/Dissertation";
				}
				if (typemake == "22") {
					type = "Encyclopedia/Dictionary";
				}
				if (typemake == "23") {
					type = "WorkAnthology";
				}
				if (typemake == "24") {
					type = "MultiVolume";
				}
				if (typemake == "25") {
					type = "Forward/Introduction";
				}
				if (typemake == "26") {
					type = "Preface/Afterword";
				}
				if (typemake == "27") {
					type = "GovPub";
				}
				
#endregion

#region ChicagoStyle

				if (style == "Chicago"){
				if (format == "Bibliography"){

				if (type == "Book"){
							bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". ");
							bib.Append(titlemake);
							bib.Append(". ");
					if (translatormake != "") {bib.Append("Translated by " + translatormake + ". ");}
					if (editormake != "") {bib.Append("Edited by " + editormake + ". ");}
							bib.Append(citymake);
							bib.Append(": ");
							bib.Append(pubmake);
							bib.Append(", ");
							bib.Append(yearmake);
							bib.Append(". ");
					}

				if (type == "PrintJournal"){
							bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". \"" + articlemake + ".\" ");
							bib.Append(journalmake + " ");
							bib.Append(": ");
							bib.Append(volumemake + "." + issuemake);
							bib.Append(" (" + yearmake + "): ");
							bib.Append(pagesmake);
							bib.Append(".");
				}

				if (type == "BookReview"){
							bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". Review of " + titlemake + ", ");
							bib.Append("Directed by " + directormake + ".");
				}

				if (type == "Magazine"){

						bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". \"" + titlemake + ".\" " + journalmake);
							bib.Append(", " + monthmake + " " + daymake + ", " + yearmake);
							bib.Append(".");

				}

				if (type == "DailyNewspaper"){

							bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". \"" + titlemake + ".\" " + journalmake);
							bib.Append(", " + monthmake + " " + yearmake);
							bib.Append(".");

				
			
				}

				if (type == "EntireWebsite" | type == "WebPage"){

					bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". ");
					if (type == "WebPage"){bib.Append("\" " + pagesmake + ".\" ");}
							bib.Append(titlemake);
							bib.Append(". ");
							if (urlmake != ""){
							bib.Append(urlmake);
					}
							if (doimake != ""){
						bib.Append(doimake);
					}
							bib.Append(". ");
				}

				if (type == "OnlineJournal"){

					bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". \"" + articlemake + ".\" ");
							bib.Append(journalmake + " ");
							bib.Append(": ");
							bib.Append(volumemake + "." + issuemake);
							bib.Append(" (" + yearmake + "): ");
							bib.Append(pagesmake + ". ");
							bib.Append("Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);
							bib.Append(". ");
							if (urlmake != ""){
							bib.Append(urlmake);
							}
							else if (doimake != ""){
							bib.Append(doimake);
							}
							bib.Append(".");


				}

				if (type == "OnlineBook"){

							bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". ");
							bib.Append(titlemake);
							bib.Append(". ");
							bib.Append(citymake);
							bib.Append(": ");
							bib.Append(pubmake);
							bib.Append(", ");
							bib.Append(yearmake + ". ");
							bib.Append("Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);

							bib.Append(". " + urlmake);
				}
				
				if (type == "OnlineMag"){
						
					bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". \"" + titlemake + ".\" " + journalmake);
							bib.Append(", " + monthmake + " " + daymake + ", " + yearmake);
							bib.Append(". ");
					bib.Append("." + urlmake);

				}
				
				if (type == "EntireBlog"){

					bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". " + titlemake + " (blog)");
							bib.Append(". ");
							bib.Append(urlmake);
				}
					
				if (type == "ResponseinBlog"){
					bib.Clear();
							var i = 0;
							bib.Append(journalmake + "; ");
							bib.Append(". \"" + titlemake + ",\" " + "blog entry by ");
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". ");
							bib.Append(monthmake + " " + daymake + ", " + yearmake);
					bib.Append(".");

				}

				if (type == "PortionOnlineBook"){

						bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". ");
							bib.Append("\"" + chaptermake + ".\" " + titlemake);
							bib.Append(". ");
							bib.Append(citymake);
							bib.Append(": ");
							bib.Append(pubmake);
							bib.Append(", ");
							bib.Append(yearmake + ". ");
							bib.Append("Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);
							bib.Append(". " + orgmake + ". " + urlmake);
				}

				if (type == "CD-Rom"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "E-Mail"){
					bib.Clear();
					bib.Append("This Format is not Supported for Bibliography");
				}

				if (type == "Video/Film"){
				
					
					bib.Clear();
							bib.Append(titlemake + ". ");
							bib.Append(countrymake + ": " + corpauthmake + ", " + yearmake + ". ");
							bib.Append(mediummake + ", " + runtimemake);
					bib.Append(".");
  
				}

				if (type == "Podcast/Youtube"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "Lecture/PublicAddress"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "Thesis/Dissertation"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "Encyclopedia/Dictionary"){

					bib.Clear();
					bib.Append("This Format is not Supported for Bibliography");
				}

				if (type == "WorkAnthology"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "MultiVolume"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "Forward/Introduction"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "Preface/Afterword"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "GovPub"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "EditorialinNewspaper"){
					bib.Clear();
					bib.Append("This Format is not Supported for Bibliography");
				}

				if (type == "LetterToEditor"){
					bib.Clear();
					bib.Append("This Format is not Supported for Bibliography");

				}


					}
					if (format == "InTextCitation"){
					if (type == "Book"){
								bib.Clear();
					bib.Append("(");
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								}
								else if (i == authors && authors < 1){
									bib.Append(lastname[i] + " ");

								}
								else {
									bib.Append(" and " + lastname[i] + " ");
								}

								++i;
							}
							bib.Append(" ");
							bib.Append(yearmake);
							bib.Append(",");
							bib.Append(pagesmake);
							bib.Append(")");
				}
		}
					if (format == "Footnote"){
						if (type == "Book"){
							bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(firstname[i] + " ");
								bib.Append(lastname[i]);
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(", ");
							bib.Append(titlemake);
							bib.Append(" (");
							bib.Append(citymake);
							bib.Append(": ");
							bib.Append(pubmake);
							bib.Append(", ");
							bib.Append(yearmake);
							bib.Append("),");
							bib.Append(pagesmake);
							bib.Append(".");
						}
					}
					if (format == "EndNote"){
						if (type == "Book"){
							bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(firstname[i] + " ");
								bib.Append(lastname[i]);
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(", ");
							bib.Append(titlemake);
							bib.Append(" (");
							bib.Append(citymake);
							bib.Append(": ");
							bib.Append(pubmake);
							bib.Append(", ");
							bib.Append(yearmake);
							bib.Append("),");
							bib.Append(pagesmake);
							bib.Append(".");
				}
					}
					if (format == "WorksCited"){
						if (type == "Book"){

					}
					}
			}
#endregion

#region APAStyle
			if (style == "APA"){
					if (format == "Bibliography"){
					
							if (type == "Book"){
							bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". ");
							bib.Append(titlemake);
							bib.Append(". ");
					if (translatormake != "") {bib.Append("Translated by " + translatormake + ". ");}
					if (editormake != "") {bib.Append("Edited by " + editormake + ". ");}
							bib.Append(citymake);
							bib.Append(": ");
							bib.Append(pubmake);
							bib.Append(", ");
							bib.Append(yearmake);
							bib.Append(". ");
					}

				if (type == "PrintJournal"){
							bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". \"" + articlemake + ".\" ");
							bib.Append(journalmake + " ");
							bib.Append(": ");
							bib.Append(volumemake + "." + issuemake);
							bib.Append(" (" + yearmake + "): ");
							bib.Append(pagesmake);
							bib.Append(".");
				}

				if (type == "BookReview"){
							bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". Review of " + titlemake + ", ");
							bib.Append("Directed by " + directormake + ".");
				}

				if (type == "Magazine"){

						bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". \"" + titlemake + ".\" " + journalmake);
							bib.Append(", " + monthmake + " " + daymake + ", " + yearmake);
							bib.Append(".");

				}

				if (type == "DailyNewspaper"){

							bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". \"" + titlemake + ".\" " + journalmake);
							bib.Append(", " + monthmake + " " + yearmake);
							bib.Append(".");

				
			
				}

				if (type == "EntireWebsite" | type == "WebPage"){

					bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". ");
					if (type == "WebPage"){bib.Append("\" " + pagesmake + ".\" ");}
							bib.Append(titlemake);
							bib.Append(". ");
							if (urlmake != ""){
							bib.Append(urlmake);
					}
							if (doimake != ""){
						bib.Append(doimake);
					}
							bib.Append(". ");
				}

				if (type == "OnlineJournal"){

					bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". \"" + articlemake + ".\" ");
							bib.Append(journalmake + " ");
							bib.Append(": ");
							bib.Append(volumemake + "." + issuemake);
							bib.Append(" (" + yearmake + "): ");
							bib.Append(pagesmake + ". ");
							bib.Append("Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);
							bib.Append(". ");
							if (urlmake != ""){
							bib.Append(urlmake);
							}
							else if (doimake != ""){
							bib.Append(doimake);
							}
							bib.Append(".");


				}

				if (type == "OnlineBook"){

							bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". ");
							bib.Append(titlemake);
							bib.Append(". ");
							bib.Append(citymake);
							bib.Append(": ");
							bib.Append(pubmake);
							bib.Append(", ");
							bib.Append(yearmake + ". ");
							bib.Append("Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);

							bib.Append(". " + urlmake);
				}
				
				if (type == "OnlineMag"){
						
					bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". \"" + titlemake + ".\" " + journalmake);
							bib.Append(", " + monthmake + " " + daymake + ", " + yearmake);
							bib.Append(". ");
					bib.Append("." + urlmake);

				}
				
				if (type == "EntireBlog"){

					bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". " + titlemake + " (blog)");
							bib.Append(". ");
							bib.Append(urlmake);
				}
					
				if (type == "ResponseinBlog"){
					bib.Clear();
							var i = 0;
							bib.Append(journalmake + "; ");
							bib.Append(". \"" + titlemake + ",\" " + "blog entry by ");
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". ");
							bib.Append(monthmake + " " + daymake + ", " + yearmake);
					bib.Append(".");

				}

				if (type == "PortionOnlineBook"){

						bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". ");
							bib.Append("\"" + chaptermake + ".\" " + titlemake);
							bib.Append(". ");
							bib.Append(citymake);
							bib.Append(": ");
							bib.Append(pubmake);
							bib.Append(", ");
							bib.Append(yearmake + ". ");
							bib.Append("Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);
							bib.Append(". " + orgmake + ". " + urlmake);
				}

				if (type == "CD-Rom"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "E-Mail"){
					bib.Clear();
					bib.Append("This Format is not Supported for Bibliography");
				}

				if (type == "Video/Film"){
				
					
					bib.Clear();
							bib.Append(titlemake + ". ");
							bib.Append(countrymake + ": " + corpauthmake + ", " + yearmake + ". ");
							bib.Append(mediummake + ", " + runtimemake);
					bib.Append(".");
  
				}

				if (type == "Podcast/Youtube"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "Lecture/PublicAddress"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "Thesis/Dissertation"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "Encyclopedia/Dictionary"){

					bib.Clear();
					bib.Append("This Format is not Supported for Bibliography");
				}

				if (type == "WorkAnthology"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "MultiVolume"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "Forward/Introduction"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "Preface/Afterword"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "GovPub"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "EditorialinNewspaper"){
					bib.Clear();
					bib.Append("This Format is not Supported for Bibliography");
				}

				if (type == "LetterToEditor"){
					bib.Clear();
					bib.Append("This Format is not Supported for Bibliography");

				}

					}
					if (format == "InTextCitation"){

					}
					if (format == "Footnote"){

					}
					if (format == "EndNote"){

					}
					if (format == "WorksCited"){

					}
				}
#endregion

#region MLAStyle
			if (style == "MLA"){
					if (format == "Bibliography"){

							if (type == "Book"){
							bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". ");
							bib.Append(titlemake);
							bib.Append(". ");
					if (translatormake != "") {bib.Append("Translated by " + translatormake + ". ");}
					if (editormake != "") {bib.Append("Edited by " + editormake + ". ");}
							bib.Append(citymake);
							bib.Append(": ");
							bib.Append(pubmake);
							bib.Append(", ");
							bib.Append(yearmake);
							bib.Append(". ");
					}

				if (type == "PrintJournal"){
							bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". \"" + articlemake + ".\" ");
							bib.Append(journalmake + " ");
							bib.Append(": ");
							bib.Append(volumemake + "." + issuemake);
							bib.Append(" (" + yearmake + "): ");
							bib.Append(pagesmake);
							bib.Append(".");
				}

				if (type == "BookReview"){
							bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". Review of " + titlemake + ", ");
							bib.Append("Directed by " + directormake + ".");
				}

				if (type == "Magazine"){

						bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". \"" + titlemake + ".\" " + journalmake);
							bib.Append(", " + monthmake + " " + daymake + ", " + yearmake);
							bib.Append(".");

				}

				if (type == "DailyNewspaper"){

							bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". \"" + titlemake + ".\" " + journalmake);
							bib.Append(", " + monthmake + " " + yearmake);
							bib.Append(".");

				
			
				}

				if (type == "EntireWebsite" | type == "WebPage"){

					bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". ");
					if (type == "WebPage"){bib.Append("\" " + pagesmake + ".\" ");}
							bib.Append(titlemake);
							bib.Append(". ");
							if (urlmake != ""){
							bib.Append(urlmake);
					}
							if (doimake != ""){
						bib.Append(doimake);
					}
							bib.Append(". ");
				}

				if (type == "OnlineJournal"){

					bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". \"" + articlemake + ".\" ");
							bib.Append(journalmake + " ");
							bib.Append(": ");
							bib.Append(volumemake + "." + issuemake);
							bib.Append(" (" + yearmake + "): ");
							bib.Append(pagesmake + ". ");
							bib.Append("Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);
							bib.Append(". ");
							if (urlmake != ""){
							bib.Append(urlmake);
							}
							else if (doimake != ""){
							bib.Append(doimake);
							}
							bib.Append(".");


				}

				if (type == "OnlineBook"){

							bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". ");
							bib.Append(titlemake);
							bib.Append(". ");
							bib.Append(citymake);
							bib.Append(": ");
							bib.Append(pubmake);
							bib.Append(", ");
							bib.Append(yearmake + ". ");
							bib.Append("Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);

							bib.Append(". " + urlmake);
				}
				
				if (type == "OnlineMag"){
						
					bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". \"" + titlemake + ".\" " + journalmake);
							bib.Append(", " + monthmake + " " + daymake + ", " + yearmake);
							bib.Append(". ");
					bib.Append("." + urlmake);

				}
				
				if (type == "EntireBlog"){

					bib.Clear();
							var i = 0;

							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". " + titlemake + " (blog)");
							bib.Append(". ");
							bib.Append(urlmake);
				}
					
				if (type == "ResponseinBlog"){
					bib.Clear();
							var i = 0;
							bib.Append(journalmake + "; ");
							bib.Append(". \"" + titlemake + ",\" " + "blog entry by ");
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". ");
							bib.Append(monthmake + " " + daymake + ", " + yearmake);
					bib.Append(".");

				}

				if (type == "PortionOnlineBook"){

						bib.Clear();
							var i = 0;
							while ( i < authors){
								if (i == 0){
								bib.Append(lastname[i]);
								bib.Append(", ");
								bib.Append(firstname[i]);
									if (i == 0 && authors > 1){
								bib.Append(", ");
										}
								}
								else if (i == authors && authors < 1){
									bib.Append(firstname[i] + " ");
									bib.Append(lastname[i]);

								}
								else {
									bib.Append(" and " + firstname[i] + " ");
									bib.Append(lastname[i]);
								}

								++i;
							}
							bib.Append(". ");
							bib.Append("\"" + chaptermake + ".\" " + titlemake);
							bib.Append(". ");
							bib.Append(citymake);
							bib.Append(": ");
							bib.Append(pubmake);
							bib.Append(", ");
							bib.Append(yearmake + ". ");
							bib.Append("Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);
							bib.Append(". " + orgmake + ". " + urlmake);
				}

				if (type == "CD-Rom"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "E-Mail"){
					bib.Clear();
					bib.Append("This Format is not Supported for Bibliography");
				}

				if (type == "Video/Film"){
				
					
					bib.Clear();
							bib.Append(titlemake + ". ");
							bib.Append(countrymake + ": " + corpauthmake + ", " + yearmake + ". ");
							bib.Append(mediummake + ", " + runtimemake);
					bib.Append(".");
  
				}

				if (type == "Podcast/Youtube"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "Lecture/PublicAddress"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "Thesis/Dissertation"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "Encyclopedia/Dictionary"){

					bib.Clear();
					bib.Append("This Format is not Supported for Bibliography");
				}

				if (type == "WorkAnthology"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "MultiVolume"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "Forward/Introduction"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "Preface/Afterword"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "GovPub"){

					bib.Clear();
					bib.Append("Not Available Yet");
				}

				if (type == "EditorialinNewspaper"){
					bib.Clear();
					bib.Append("This Format is not Supported for Bibliography");
				}

				if (type == "LetterToEditor"){
					bib.Clear();
					bib.Append("This Format is not Supported for Bibliography");

				}

					}
					if (format == "InTextCitation"){

					}
					if (format == "Footnote"){

					}
					if (format == "EndNote"){

					}
					if (format == "WorksCited"){

					}
				}
#endregion
		output = bib.ToString();
			}

	public void outputentry ()
		{
//			using (StreamWriter writer = new StreamWriter("bib.html")) {
//				writer.WriteLine("<html>");
//				writer.WriteLine ("<head>");
//				writer.WriteLine("</head>");
//				writer.WriteLine("<body>");
//				writer.WriteLine(output);
//				writer.WriteLine("</body>");
//				writer.WriteLine("</html>");
//			writer.Close ();
//			}
		textview2.Buffer.Text = output;
		}

	public void requiredField ()
		{
			dialog dialog = new dialog();
		}	
	protected void refreshEvent (object sender, EventArgs e)
	{
		update();
		Console.WriteLine("refresh");
	}	
	protected void clearEvent (object sender, EventArgs e)
	{
		using (StreamWriter writer = new StreamWriter(database)) {
			writer.WriteLine ("<?xml version='1.0' encoding='ISO-8859-1'?>");
				writer.WriteLine ("<ENTRIES>");
				writer.WriteLine("</ENTRIES>");
			writer.Close();
		}
	}	

	protected void listEvent (object sender, EventArgs e)
	{
		listentries();
	}




}
}