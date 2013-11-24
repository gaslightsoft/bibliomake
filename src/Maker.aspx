<%@ Page Language="C#" Inherits="WebBIblio.Maker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<html>
	<head runat="server">
		<title>Bibliography Maker</title>
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
		<script runat="server" type="text/javascript">
		</script>
	</head>
	<body>
		<div id="form">
			<form name="form" runat="server">
				<input type="hidden" name="func_name" value="ADD_USER" />
				<div><a href="Default.aspx">Add Bibliography Entries</a></div>
				<table border="1" class="format">
<td>
							<label>Style:</label><select runat="server" name="style" id="bibstyle" onchange="selectevent">
								<option value="0">Select One</option>
								<option value="1">Chicago</option>
								<option value="2">APA</option>
								<option value="3">MLA</option>
								</select>
						</td>
						<td>
							<label>Format:</label><select runat="server" name="format" id="bibformat" onchange="selectevent">
								<option value="0">Select One</option>
								<option value="1">Bibliography</option>
								<option value="2">In Text Citation</option>
								<option value="3">Footnote</option>
								<option value="4">End note</option>
								<option value="5">Works Cited</option>
								</select>
						</td>
						<td>
							<label>Entry:</label><select runat="server" name="entry" id="bibentry" onchange="selectevent">
								<option value="0">Select One</option>
								<option value="1">Bibliography</option>
								<option value="2">In Text Citation</option>
								<option value="3">Footnote</option>
								<option value="4">End note</option>
								<option value="5">Works Cited</option>
								</select>
							
						</td>
				</table>
				<asp:Button runat="server" Text="SUBMIT" id="submit" OnClick="selectevent" />
			</form>
		</div>
		<iframe height="100%" width="100%" src="bib.html"></iframe>
	</body>
</html>