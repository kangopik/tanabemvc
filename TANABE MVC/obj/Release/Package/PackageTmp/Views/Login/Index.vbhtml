<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
    <meta charset="UTF-8" />  
    <link href="~/Content/css/reset.css" rel="stylesheet" />
    <link href="~/Content/css/structure.css" rel="stylesheet" />
    <script src="~/Content/js/jquery.js"></script>
    
</head>

<body>

        @Using (Html.BeginForm("login", "login", method:=FormMethod.Post, htmlAttributes:=New With {Key .[class] = "box login"}))
            @<fieldset class="boxBody">
                <label>Username</label>
                <input name="username" type="text" tabindex="1" placeholder="" required>
                <label>Password</label>
                <input name="password" type="password" tabindex="2" required>
            </fieldset>
            @<footer>
                <input type="submit" class="btnLogin" value="Login" tabindex="4"> 
                 <label>@ViewBag.MsgError</label>
            </footer>
        End Using
   
</body>
</html>
