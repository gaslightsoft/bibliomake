using System;
using Mono.WebBrowser;
using Gtk;
using System.Net;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.XPath;

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
		listentries(combobox3);
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Gtk.Application.Quit ();
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
				//outputentry ();
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

	public void listentries (ComboBox combobox)
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

				combobox.RemoveText(i);
				combobox.InsertText (i,node.ToString());
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
			var tag = new TextTag(null);
			this.textview1.Buffer.TagTable.Add (tag);
			tag.Style = Pango.Style.Italic;
			var iter = this.textview1.Buffer.GetIterAtLine(0);
			
				if (style == "Chicago"){
				if (format == "Bibliography"){

				if (type == "Book"){
						textview1.Buffer.Text = "";

						iter = this.textview1.Buffer.GetIterAtLine(0);

							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". ");
							
						if (titlemake != ""){ this.textview1.Buffer.InsertWithTags (ref iter,titlemake, tag);}
							this.textview1.Buffer.Insert (ref iter, ". ");
					if (translatormake != ""){bib.Append( "Translated by " + translatormake + ". ");}
					if (editormake != ""){bib.Append( "Edited by " + editormake + ". ");}
							this.textview1.Buffer.Insert (ref iter, citymake);
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, pubmake);
							this.textview1.Buffer.Insert (ref iter, ", ");
							this.textview1.Buffer.Insert (ref iter, yearmake);
							this.textview1.Buffer.Insert (ref iter, ". ");
					}

				if (type == "PrintJournal"){
							textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". \"" + articlemake + ".\" ");
							this.textview1.Buffer.InsertWithTags (ref iter,journalmake,tag);
						    this.textview1.Buffer.Insert (ref iter," ");
							this.textview1.Buffer.Insert (ref iter, " ");
							this.textview1.Buffer.Insert (ref iter, volumemake + "." + issuemake);
							this.textview1.Buffer.Insert (ref iter, " (" + yearmake + "): ");
							this.textview1.Buffer.Insert (ref iter, pagesmake);
							this.textview1.Buffer.Insert (ref iter, ".");
				}

				if (type == "BookReview"){
						textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
						this.textview1.Buffer.Insert (ref iter, ". Review of ");
						this.textview1.Buffer.InsertWithTags(ref iter, titlemake,tag);
						this.textview1.Buffer.Insert (ref iter, ", ");
							this.textview1.Buffer.Insert (ref iter, "Directed by " + directormake + ". ");
						this.textview1.Buffer.InsertWithTags (ref iter,journalmake,tag);
						  	this.textview1.Buffer.Insert (ref iter, ", ");
						this.textview1.Buffer.Insert (ref iter, monthmake + " " + daymake + ", " + yearmake + ", " + editionmake + ".");

				}

				if (type == "Magazine"){

						textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". \"" + titlemake + ".\" " + journalmake);
							this.textview1.Buffer.Insert (ref iter, ", " + monthmake + " " + daymake + ", " + yearmake);
							this.textview1.Buffer.Insert (ref iter, ".");

				}

				if (type == "DailyNewspaper"){

							textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". \"" + titlemake + ".\" " + journalmake);
							this.textview1.Buffer.Insert (ref iter, ", " + monthmake + " " + yearmake);
							this.textview1.Buffer.Insert (ref iter, ".");

				
			
				}

				if (type == "EntireWebsite" | type == "WebPage"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". ");
					if (type == "WebPage"){this.textview1.Buffer.Insert (ref iter, "\" " + pagesmake + ".\" ");}
							this.textview1.Buffer.InsertWithTags (ref iter, titlemake, tag);
							this.textview1.Buffer.Insert (ref iter, ". ");
							if (urlmake != ""){
							this.textview1.Buffer.Insert (ref iter, urlmake);
					}
							if (doimake != ""){
						this.textview1.Buffer.Insert (ref iter, doimake);
					}
							this.textview1.Buffer.Insert (ref iter, ". ");
				}

				if (type == "OnlineJournal"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". \"" + articlemake + ".\" ");
							this.textview1.Buffer.Insert (ref iter, journalmake + " ");
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, volumemake + "." + issuemake);
							this.textview1.Buffer.Insert (ref iter, " (" + yearmake + "): ");
							this.textview1.Buffer.Insert (ref iter, pagesmake + ". ");
							this.textview1.Buffer.Insert (ref iter, "Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);
							this.textview1.Buffer.Insert (ref iter, ". ");
							if (urlmake != ""){
							this.textview1.Buffer.Insert (ref iter, urlmake);
							}
							else if (doimake != ""){
							this.textview1.Buffer.Insert (ref iter, doimake);
							}
							this.textview1.Buffer.Insert (ref iter, ".");


				}

				if (type == "OnlineBook"){

							textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.InsertWithTags (ref iter,titlemake, tag);
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, citymake);
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, pubmake);
							this.textview1.Buffer.Insert (ref iter, ", ");
							this.textview1.Buffer.Insert (ref iter, yearmake + ". ");
							this.textview1.Buffer.Insert (ref iter, "Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);

							this.textview1.Buffer.Insert (ref iter, ". " + urlmake);
				}
				
				if (type == "OnlineMag"){
						
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
						this.textview1.Buffer.Insert (ref iter, ". \"" + titlemake + ".\" ");
						    this.textview1.Buffer.InsertWithTags (ref iter, journalmake, tag);
							this.textview1.Buffer.Insert (ref iter, ", " + monthmake + " " + daymake + ", " + yearmake);
							this.textview1.Buffer.Insert (ref iter, ". ");
					this.textview1.Buffer.Insert (ref iter, "." + urlmake);

				}
				
				if (type == "EntireBlog"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
						this.textview1.Buffer.Insert (ref iter, ". ");
						                         this.textview1.Buffer.InsertWithTags (ref iter, titlemake, tag);
						                         this.textview1.Buffer.Insert (ref iter," (blog)");
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, urlmake);
				}
					
				if (type == "ResponseinBlog"){
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							this.textview1.Buffer.Insert (ref iter, journalmake + "; ");
							this.textview1.Buffer.Insert (ref iter, ". \"" + titlemake + ",\" " + "blog entry by ");
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, monthmake + " " + daymake + ", " + yearmake);
					this.textview1.Buffer.Insert (ref iter, ".");

				}

				if (type == "PortionOnlineBook"){

						textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". ");
						this.textview1.Buffer.Insert (ref iter, "\"" + chaptermake + ".\" ");
						    this.textview1.Buffer.InsertWithTags (ref iter, titlemake, tag);
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, citymake);
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, pubmake);
							this.textview1.Buffer.Insert (ref iter, ", ");
							this.textview1.Buffer.Insert (ref iter, yearmake + ". ");
							this.textview1.Buffer.Insert (ref iter, "Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);
							this.textview1.Buffer.Insert (ref iter, ". " + orgmake + ". " + urlmake);
				}

				if (type == "CD-Rom"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "E-Mail"){
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "This Format is not Supported for Bibliography");
				}

				if (type == "Video/Film"){
				
					
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
						this.textview1.Buffer.InsertWithTags (ref iter, titlemake,tag);
						this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, countrymake + ": " + corpauthmake + ", " + yearmake + ". ");
							this.textview1.Buffer.Insert (ref iter, mediummake + ", " + runtimemake);
					this.textview1.Buffer.Insert (ref iter, ".");
  
				}

				if (type == "Podcast/Youtube"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "Lecture/PublicAddress"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "Thesis/Dissertation"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "Encyclopedia/Dictionary"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "This Format is not Supported for Bibliography");
				}

				if (type == "WorkAnthology"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "MultiVolume"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "Forward/Introduction"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "Preface/Afterword"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "GovPub"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "EditorialinNewspaper"){
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "This Format is not Supported for Bibliography");
				}

				if (type == "LetterToEditor"){
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "This Format is not Supported for Bibliography");

				}


					}
					if (format == "InTextCitation"){
					if (type == "Book"){
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "(");
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, lastname[i] + " ");

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + lastname[i] + " ");
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, " ");
							this.textview1.Buffer.Insert (ref iter, yearmake);
							this.textview1.Buffer.Insert (ref iter, ",");
							this.textview1.Buffer.Insert (ref iter, pagesmake);
							this.textview1.Buffer.Insert (ref iter, ")");
				}
		}
					if (format == "Footnote"){
						if (type == "Book"){
							textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ", ");
							this.textview1.Buffer.Insert (ref iter, titlemake);
							this.textview1.Buffer.Insert (ref iter, " (");
							this.textview1.Buffer.Insert (ref iter, citymake);
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, pubmake);
							this.textview1.Buffer.Insert (ref iter, ", ");
							this.textview1.Buffer.Insert (ref iter, yearmake);
							this.textview1.Buffer.Insert (ref iter, "),");
							this.textview1.Buffer.Insert (ref iter, pagesmake);
							this.textview1.Buffer.Insert (ref iter, ".");
						}
					}
					if (format == "EndNote"){
						if (type == "Book"){
							textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ", ");
							this.textview1.Buffer.Insert (ref iter, titlemake);
							this.textview1.Buffer.Insert (ref iter, " (");
							this.textview1.Buffer.Insert (ref iter, citymake);
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, pubmake);
							this.textview1.Buffer.Insert (ref iter, ", ");
							this.textview1.Buffer.Insert (ref iter, yearmake);
							this.textview1.Buffer.Insert (ref iter, "),");
							this.textview1.Buffer.Insert (ref iter, pagesmake);
							this.textview1.Buffer.Insert (ref iter, ".");
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
							textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, titlemake);
							this.textview1.Buffer.Insert (ref iter, ". ");
					if (translatormake != ""){bib.Append( "Translated by " + translatormake + ". ");}
					if (editormake != ""){bib.Append( "Edited by " + editormake + ". ");}
							this.textview1.Buffer.Insert (ref iter, citymake);
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, pubmake);
							this.textview1.Buffer.Insert (ref iter, ", ");
							this.textview1.Buffer.Insert (ref iter, yearmake);
							this.textview1.Buffer.Insert (ref iter, ". ");
					}



				if (type == "PrintJournal"){
							textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". \"" + articlemake + ".\" ");
							this.textview1.Buffer.Insert (ref iter, journalmake + " ");
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, volumemake + "." + issuemake);
							this.textview1.Buffer.Insert (ref iter, " (" + yearmake + "): ");
							this.textview1.Buffer.Insert (ref iter, pagesmake);
							this.textview1.Buffer.Insert (ref iter, ".");
				}

				if (type == "BookReview"){
							textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". Review of " + titlemake + ", ");
							this.textview1.Buffer.Insert (ref iter, "Directed by " + directormake + ".");
				}

				if (type == "Magazine"){

						textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". \"" + titlemake + ".\" " + journalmake);
							this.textview1.Buffer.Insert (ref iter, ", " + monthmake + " " + daymake + ", " + yearmake);
							this.textview1.Buffer.Insert (ref iter, ".");

				}

				if (type == "DailyNewspaper"){

							textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
							else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". \"" + titlemake + ".\" " + journalmake);
							this.textview1.Buffer.Insert (ref iter, ", " + monthmake + " " + yearmake);
							this.textview1.Buffer.Insert (ref iter, ".");

				
			
				}

				if (type == "EntireWebsite" | type == "WebPage"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". ");
					if (type == "WebPage"){this.textview1.Buffer.Insert (ref iter, "\" " + pagesmake + ".\" ");}
							this.textview1.Buffer.Insert (ref iter, titlemake);
							this.textview1.Buffer.Insert (ref iter, ". ");
							if (urlmake != ""){
							this.textview1.Buffer.Insert (ref iter, urlmake);
					}
							if (doimake != ""){
						this.textview1.Buffer.Insert (ref iter, doimake);
					}
							this.textview1.Buffer.Insert (ref iter, ". ");
				}

				if (type == "OnlineJournal"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". \"" + articlemake + ".\" ");
							this.textview1.Buffer.Insert (ref iter, journalmake + " ");
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, volumemake + "." + issuemake);
							this.textview1.Buffer.Insert (ref iter, " (" + yearmake + "): ");
							this.textview1.Buffer.Insert (ref iter, pagesmake + ". ");
							this.textview1.Buffer.Insert (ref iter, "Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);
							this.textview1.Buffer.Insert (ref iter, ". ");
							if (urlmake != ""){
							this.textview1.Buffer.Insert (ref iter, urlmake);
							}
							else if (doimake != ""){
							this.textview1.Buffer.Insert (ref iter, doimake);
							}
							this.textview1.Buffer.Insert (ref iter, ".");


				}

				if (type == "OnlineBook"){

							textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, titlemake);
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, citymake);
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, pubmake);
							this.textview1.Buffer.Insert (ref iter, ", ");
							this.textview1.Buffer.Insert (ref iter, yearmake + ". ");
							this.textview1.Buffer.Insert (ref iter, "Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);

							this.textview1.Buffer.Insert (ref iter, ". " + urlmake);
				}
				
				if (type == "OnlineMag"){
						
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". \"" + titlemake + ".\" " + journalmake);
							this.textview1.Buffer.Insert (ref iter, ", " + monthmake + " " + daymake + ", " + yearmake);
							this.textview1.Buffer.Insert (ref iter, ". ");
					this.textview1.Buffer.Insert (ref iter, "." + urlmake);

				}
				
				if (type == "EntireBlog"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". " + titlemake + " (blog)");
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, urlmake);
				}
					
				if (type == "ResponseinBlog"){
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							this.textview1.Buffer.Insert (ref iter, journalmake + "; ");
							this.textview1.Buffer.Insert (ref iter, ". \"" + titlemake + ",\" " + "blog entry by ");
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, monthmake + " " + daymake + ", " + yearmake);
					this.textview1.Buffer.Insert (ref iter, ".");

				}

				if (type == "PortionOnlineBook"){

						textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, "\"" + chaptermake + ".\" " + titlemake);
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, citymake);
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, pubmake);
							this.textview1.Buffer.Insert (ref iter, ", ");
							this.textview1.Buffer.Insert (ref iter, yearmake + ". ");
							this.textview1.Buffer.Insert (ref iter, "Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);
							this.textview1.Buffer.Insert (ref iter, ". " + orgmake + ". " + urlmake);
				}

				if (type == "CD-Rom"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "E-Mail"){
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "This Format is not Supported for Bibliography");
				}

				if (type == "Video/Film"){
				
					
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							this.textview1.Buffer.Insert (ref iter, titlemake + ". ");
							this.textview1.Buffer.Insert (ref iter, countrymake + ": " + corpauthmake + ", " + yearmake + ". ");
							this.textview1.Buffer.Insert (ref iter, mediummake + ", " + runtimemake);
					this.textview1.Buffer.Insert (ref iter, ".");
  
				}

				if (type == "Podcast/Youtube"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "Lecture/PublicAddress"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "Thesis/Dissertation"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "Encyclopedia/Dictionary"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "This Format is not Supported for Bibliography");
				}

				if (type == "WorkAnthology"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "MultiVolume"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "Forward/Introduction"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "Preface/Afterword"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "GovPub"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "EditorialinNewspaper"){
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "This Format is not Supported for Bibliography");
				}

				if (type == "LetterToEditor"){
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "This Format is not Supported for Bibliography");

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
							textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, titlemake);
							this.textview1.Buffer.Insert (ref iter, ". ");
					if (translatormake != ""){bib.Append( "Translated by " + translatormake + ". ");}
					if (editormake != ""){bib.Append( "Edited by " + editormake + ". ");}
							this.textview1.Buffer.Insert (ref iter, citymake);
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, pubmake);
							this.textview1.Buffer.Insert (ref iter, ", ");
							this.textview1.Buffer.Insert (ref iter, yearmake);
							this.textview1.Buffer.Insert (ref iter, ". ");
					}

				if (type == "PrintJournal"){
							textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". \"" + articlemake + ".\" ");
							this.textview1.Buffer.Insert (ref iter, journalmake + " ");
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, volumemake + "." + issuemake);
							this.textview1.Buffer.Insert (ref iter, " (" + yearmake + "): ");
							this.textview1.Buffer.Insert (ref iter, pagesmake);
							this.textview1.Buffer.Insert (ref iter, ".");
				}

				if (type == "BookReview"){
							textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". Review of " + titlemake + ", ");
							this.textview1.Buffer.Insert (ref iter, "Directed by " + directormake + ".");
				}

				if (type == "Magazine"){

						textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". \"" + titlemake + ".\" " + journalmake);
							this.textview1.Buffer.Insert (ref iter, ", " + monthmake + " " + daymake + ", " + yearmake);
							this.textview1.Buffer.Insert (ref iter, ".");

				}

				if (type == "DailyNewspaper"){

							textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". \"" + titlemake + ".\" " + journalmake);
							this.textview1.Buffer.Insert (ref iter, ", " + monthmake + " " + yearmake);
							this.textview1.Buffer.Insert (ref iter, ".");

				
			
				}

				if (type == "EntireWebsite" | type == "WebPage"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". ");
					if (type == "WebPage"){this.textview1.Buffer.Insert (ref iter, "\" " + pagesmake + ".\" ");}
							this.textview1.Buffer.Insert (ref iter, titlemake);
							this.textview1.Buffer.Insert (ref iter, ". ");
							if (urlmake != ""){
							this.textview1.Buffer.Insert (ref iter, urlmake);
					}
							if (doimake != ""){
						this.textview1.Buffer.Insert (ref iter, doimake);
					}
							this.textview1.Buffer.Insert (ref iter, ". ");
				}

				if (type == "OnlineJournal"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". \"" + articlemake + ".\" ");
							this.textview1.Buffer.Insert (ref iter, journalmake + " ");
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, volumemake + "." + issuemake);
							this.textview1.Buffer.Insert (ref iter, " (" + yearmake + "): ");
							this.textview1.Buffer.Insert (ref iter, pagesmake + ". ");
							this.textview1.Buffer.Insert (ref iter, "Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);
							this.textview1.Buffer.Insert (ref iter, ". ");
							if (urlmake != ""){
							this.textview1.Buffer.Insert (ref iter, urlmake);
							}
							else if (doimake != ""){
							this.textview1.Buffer.Insert (ref iter, doimake);
							}
							this.textview1.Buffer.Insert (ref iter, ".");


				}

				if (type == "OnlineBook"){

							textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, titlemake);
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, citymake);
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, pubmake);
							this.textview1.Buffer.Insert (ref iter, ", ");
							this.textview1.Buffer.Insert (ref iter, yearmake + ". ");
							this.textview1.Buffer.Insert (ref iter, "Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);

							this.textview1.Buffer.Insert (ref iter, ". " + urlmake);
				}
				
				if (type == "OnlineMag"){
						
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". \"" + titlemake + ".\" " + journalmake);
							this.textview1.Buffer.Insert (ref iter, ", " + monthmake + " " + daymake + ", " + yearmake);
							this.textview1.Buffer.Insert (ref iter, ". ");
					this.textview1.Buffer.Insert (ref iter, "." + urlmake);

				}
				
				if (type == "EntireBlog"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;

							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". " + titlemake + " (blog)");
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, urlmake);
				}
					
				if (type == "ResponseinBlog"){
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							this.textview1.Buffer.Insert (ref iter, journalmake + "; ");
							this.textview1.Buffer.Insert (ref iter, ". \"" + titlemake + ",\" " + "blog entry by ");
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, monthmake + " " + daymake + ", " + yearmake);
					this.textview1.Buffer.Insert (ref iter, ".");

				}

				if (type == "PortionOnlineBook"){

						textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							var i = 0;
							while ( i < authors){
								if (i == 0){
								this.textview1.Buffer.Insert (ref iter, lastname[i]);
								this.textview1.Buffer.Insert (ref iter, ", ");
								this.textview1.Buffer.Insert (ref iter, firstname[i]);
									if (i == 0 && authors > 1){
								this.textview1.Buffer.Insert (ref iter, ", ");
										}
								}
								else if (i == authors && authors < 1){
									this.textview1.Buffer.Insert (ref iter, firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);

								}
								else {
									this.textview1.Buffer.Insert (ref iter, " and " + firstname[i] + " ");
									this.textview1.Buffer.Insert (ref iter, lastname[i]);
								}

								++i;
							}
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, "\"" + chaptermake + ".\" " + titlemake);
							this.textview1.Buffer.Insert (ref iter, ". ");
							this.textview1.Buffer.Insert (ref iter, citymake);
							this.textview1.Buffer.Insert (ref iter, ": ");
							this.textview1.Buffer.Insert (ref iter, pubmake);
							this.textview1.Buffer.Insert (ref iter, ", ");
							this.textview1.Buffer.Insert (ref iter, yearmake + ". ");
							this.textview1.Buffer.Insert (ref iter, "Accessed" + accessmonthmake + " " + accessdaymake + ", " + accessyearmake);
							this.textview1.Buffer.Insert (ref iter, ". " + orgmake + ". " + urlmake);
				}

				if (type == "CD-Rom"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "E-Mail"){
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "This Format is not Supported for Bibliography");
				}

				if (type == "Video/Film"){
				
					
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
							this.textview1.Buffer.Insert (ref iter, titlemake + ". ");
							this.textview1.Buffer.Insert (ref iter, countrymake + ": " + corpauthmake + ", " + yearmake + ". ");
							this.textview1.Buffer.Insert (ref iter, mediummake + ", " + runtimemake);
					this.textview1.Buffer.Insert (ref iter, ".");
  
				}

				if (type == "Podcast/Youtube"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "Lecture/PublicAddress"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "Thesis/Dissertation"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "Encyclopedia/Dictionary"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "This Format is not Supported for Bibliography");
				}

				if (type == "WorkAnthology"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "MultiVolume"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "Forward/Introduction"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "Preface/Afterword"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "GovPub"){

					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "Not Available Yet");
				}

				if (type == "EditorialinNewspaper"){
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "This Format is not Supported for Bibliography");
				}

				if (type == "LetterToEditor"){
					textview1.Buffer.Text = "";
						iter = this.textview1.Buffer.GetIterAtLine(0);
					this.textview1.Buffer.Insert (ref iter, "This Format is not Supported for Bibliography");

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
			}

	public void outputentry ()
		{

			//BiblographyMaker.richText ric = richtext1;
		}

	public void requiredField ()
		{
			dialog dialog = new dialog();
		}	
	protected void refreshEvent (object sender, EventArgs e)
				{
					update ();
					listentries (combobox4);
					
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
		listentries(combobox3);
	}
	private void Navigate(String address)
	{
	
}		
	protected void OnSubmit1Pressed (object sender, EventArgs e)
		{
		entrymake = combobox4.Active.ToString();
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
		string[] data2 = new string[36];

		

		data[0] = type1.Active.ToString();
		data [2] = title1.Text.ToString();
		data [3] = day1.Text.ToString();
		data [4] = month1.Text.ToString();
		data [5] = year1.Text.ToString();
		data [6] = corpauth1.Text.ToString();
		data [7] = pub1.Text;
		data [8] = city1.Text.ToString();
		data [9] = country1.Text.ToString();
		data [10] = journal1.Text.ToString();
		data [11] =	article1.Text.ToString();
		data [12]=	volume1.Text.ToString();
		data [13]=	issue1.Text.ToString() ;
		data [14]=	issn1.Text.ToString();
		data [15]=	isbn1.Text.ToString();
		data [16]=	loc1.Text.ToString();
		data [17]=	doi1.Text.ToString();
		data [18]=	url1.Text.ToString();
		data [19]=	medium1.Text.ToString();
		data [20]=	edition1.Text.ToString();
		data [21]=	institution1.Text.ToString();
		data [22]=	pubtype1.Text.ToString();
		data [23]=	chapter1.Text.ToString();
		data [24]=	pages1.Text.ToString();
		data [25]=	series1.Text.ToString();
		data [26]=	org1.Text.ToString();
		data [27]=	university1.Text.ToString();
		data [28] =editor1.Text.ToString();
		data [29] =translator1.Text.ToString();
		data [30]=	etcetera1.Text.ToString();
		data [31]=	director1.Text.ToString();
		data [32]=	accessday1.Text.ToString();
		data [33]=	accessmonth1.Text.ToString();
		data [34]=	accessyear1.Text.ToString();
		data [35]=	runtime1.Text.ToString();
		data [1] = annotation1.Buffer.Text.ToString();

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

			edit (data, element, data2, entrymake, firstname, middlename, lastname);
}

	public void edit (string[] data, 
		                  string[] element, 
		                  string[] data2, 
		                  string entrymake, 
		                  string[] firstname,
		                  string[] middlename, 
		                  string[] lastname)
		{
		
		int i = 0;
		foreach (string a in element) {
			XmlDocument d = new XmlDocument ();
			d.Load (database);
			XmlNodeList n = d.GetElementsByTagName (a + entrymake);
			if (n != null) {
				foreach (XmlNode curr in n) {
					data2 [i] = (curr.InnerText);

				}
			}
			++i;
		}

		i = 0;
		foreach (string a in element) {

						List<string> lines = new List<string> (File.ReadAllLines (database));
						int lineIndex = lines.FindIndex (line => line.StartsWith ("  <" + a + entrymake + ">"+ data2[i] +"</" + a + entrymake + ">"));
						if (lineIndex != -1) {
							//Console.WriteLine(lineIndex);
							lines [lineIndex] = "  <" + a + entrymake +">" + data[i] +  "</" + a + entrymake +">";
					Console.WriteLine(lines.ToString());
						File.WriteAllLines (database, lines);

						}
						lineIndex = lines.FindIndex (line => line.StartsWith ("    <" + a + entrymake + ">"+ data2[i] +"</" + a + entrymake + ">"));
						if (lineIndex != -1) {
							//Console.WriteLine(lineIndex);
							lines [lineIndex] = "  <" + a + entrymake +">" + data[i] +  "</" + a + entrymake +">";
					Console.WriteLine(lines.ToString());
						File.WriteAllLines (database, lines);

						}
			++i;
		}
				
		}		

		public void setedit ()
		{
		entrymake = combobox4.Active.ToString ();
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
			i = 0;
			name1.Text = "";

			type1.Active = Convert.ToInt32(data[0]);
			title1.Text = data[2];
			day1.Text = data [3];
			month1.Text = data [4];
			year1.Text = data [5];
			corpauth1.Text = data [6];
			pub1.Text = data [7];
			city1.Text = data [8];
			country1.Text = data [9];
			journal1.Text = data [10];
			article1.Text = data [11];
			volume1.Text = data [12];
			issue1.Text = data [13];
			issn1.Text = data [14];
			isbn1.Text = data [15];
			loc1.Text = data [16];
			doi1.Text = data [17];
			url1.Text = data [18];
			medium1.Text = data [19];
			edition1.Text = data [20];
			institution1.Text = data [21];
			pubtype1.Text = data [22];
			chapter1.Text = data [23];
			pages1.Text = data [24];
			series1.Text = data [25];
			org1.Text = data [26];
			university1.Text = data [27];
			editor1.Text = data [28];
			translator1.Text = data [29];
			etcetera1.Text = data [30];
			director1.Text = data [31];
			accessday1.Text = data [32];
			accessmonth1.Text = data [33];
			accessyear1.Text = data [34];
			runtime1.Text = data [35];
			annotation1.Buffer.Text = data [1];
		}
		protected void OnButton97Pressed (object sender, EventArgs e)
		{
			setedit ();
		}

	}
}