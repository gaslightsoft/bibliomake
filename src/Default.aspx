<%@ Page Language="C#" Inherits="WebBIblio.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<html>
	<head runat="server">
		<title>Bibliography Indexer</title>
		<style>
		.label{
			width:100px;
		}
		.format{
			width:100%;
			background-color:green;
		}
		
		.publish{
			width:100%;
			background-color:blue;
		}
		
		.info{
			width:100%;
			background-color:red;
		}
		
		.misc{
			background-color:yellow;
			width:100%;
		}
		
		.annotation{
			background-color:green;
			width:100%;
			height:300px;
		}
		
		.textarea{
			width:100%;
			height:100%;
		}
		</style>
		
	</head>
	<body>
		<div id="form">
			<form name="form" runat="server">
				<input type="hidden" name="func_name" value="ADD_USER" />
				<div><a href="Maker.aspx">Make Bibliography/Citation/Footnotes</a></div>
				<table border="1" class="format">
					<tr>
						<td>
						
							<label>Medium:</label><select runat="server" name="type" id="type">
								<option value="0">Select One</option>
								<option value="1">Book</option>
								<option value="2">Journal</option>
								<option value="3">Journal Article</option>
								<option value="4">Website</option>
								<option value="5">Article on Website</option>
								<option value="6">PDF Document Article</option>
								<option value="7">PDF Document Journal</option>
								<option value="8">Chapter in Book</option>
								<option value="9">Section in Book</option>
								<option value="10">News Report</option>
								<option value="11">PDF News Report</option>
								<option value="12">Movie</option>
								<option value="13">News Report (Film)</option>
								<option value="14">Documentary</option>
							</select>
						</td>
						<td>
							<label>  DOP  </label>
						</td>
						<td>
							<label>Day</label><input runat="server" size="2" type="text" name="day" id="day" />
						</td>
						<td>
							<label>Month</label><input runat="server" size="2" type="text" name="month" id="month" />
						</td>
						<td>
							<label>Year</label><input runat="server" size="4" type="text" name="year" id="year"/>
						</td>
					</tr>
				</table>
				<table border="1" class="info">
					<tr>
						<td>
							<label>Title:</label><input runat="server" size="100" type="text" name="title" id="title"/>
						</td>
						<td><label>BibName:</label><input runat="server" size="4" type="text" name="name" id="bibname" /></td>
					</tr>
					<tr>
						<td>
							<div id="authors">
								<label>Author-Name [First,Last,Middle;]:</label><input runat="server" type="text" name="authors" id="name"/>
							</div>
						</td>
						<td><label>Multiple Authors</label><asp:CheckBox runat="server"  id="checkbox" /></td>
					</tr>
					<tr>
						<td>
							<div id="corp">
								<label>Corporate Author:</label><input runat="server" size="100" type="text" name="corpauth" id="corpauth" />
							</div>
						</td>
					</tr>
				</table>
				<table  border="1" class="publish">
					<tr>
						<td>
							<div id="publish">
								<label>Publisher</label><input runat="server" type="text" name="publisher" id="pub" />
								<label>City</label><input runat="server" type="text" name="city" id="city"/>
								<label>Country</label><input runat="server" type="text" name="country" id="country" />
								
							</div>
						</td>
					</tr>
					<tr>
						<td>
							<div id="journal">
								<label>Journal Title</label><input runat="server" type="text" name="journaltitle" id="journaltitle"/>
								<label>Journal Author</label><input runat="server" type="text" name="journalauth" id="journalauth" />
								<label>Volume</label><input runat="server" type="text" name="volume" id="volume" />
								<label>Issue</label><input runat="server" type="text" name="issue" id="issue" />
							</div>
						</td>
					</tr>
				</table>
				<table border="1" class="misc" id="misc">
					<tr>
						<td class="label">
							<label>ISSN </label>
						</td>
						<td>
							<input runat="server" type="text" name="issn" id="issn" />
						</td>
						<td rowspan="17">
							<iframe height="100%" width="100%" src="database.xml"></iframe>
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>ISBN </label>
						</td>
						<td>
							<input runat="server" type="text" name="isbn" id="isbn" />
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>Library of Congress</label>
						</td>
						<td>
							<input runat="server" type="text" name="loc" id="loc" />
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>DOI</label>
						</td>
						<td>
							<input runat="server" type="text" name="doi" id="doi" />
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>URL</label>
						</td>
						<td>
							<input runat="server" type="text" name="url" id="url" />
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>Medium</label>
						</td>
						<td>
							<input runat="server" type="text" name="medium" id="medium" />
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>Edition</label>
						</td>
						<td>
							<input runat="server" type="text" name="edition" id="edition" />
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>Institution</label>
						</td>
						<td>
							<input runat="server" type="text" name="institution" id="institution" />
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>Publication Type</label>
						</td>
						<td>
							<input runat="server" type="text" name="publicationtype" id="publicationtype" />
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>Chapter</label>
						</td>
						<td>
							<input runat="server"  type="text" name="chapter" id="chapter" />
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>Page(s)</label>
						</td>
						<td>
							<input runat="server" type="text" name="pages" id="pages" />
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>Series</label>
						</td>
						<td>
							<input runat="server" type="text" name="series" id="series" />
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>Organization</label>
						</td>
						<td>
							<input runat="server" type="text" name="org" id="org" />
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>University</label>
						</td>
						<td>
							<input runat="server" type="text" name="university" id="university" />
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>Editor</label>
						</td>
						<td>
							<input runat="server" type="text" name="editor" id="editor" />
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>Translator</label>
						</td>
						<td>
							<input runat="server" type="text" name="translator" id="translator"/>
						</td>
					</tr>
					<tr>
						<td class="label">
							<label>Et Cetera</label>
						</td>
						<td>
							<input runat="server" type="text" name="etcetera" id="etcetera" />
						</td>
					</tr>
				</table>
				<table border="1" class="annotation">
					<tr>
						<td class="label">
							<label>Annotation</label>
						</td>
						<td>
							<textarea runat="server" class="textarea" name="annotation" id="annotation"></textarea>
						</td>					
					</tr>		
				</table>
				<asp:Button runat="server" Text="Submit" id="submit" OnClick="button1Clicked" />
			</form>
		</div>
	</body>
</html>

