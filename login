<div class="Login">

    @if (Model.hasData)
    {
        @if (TempData["Login"]!=null)
        {
            <h4 align="center">@TempData["Login"]</h4>
        }
       
    }
    <h1>Login</h1>

    <div class="container">
        <form method="post">

            <label for="email">Email Address</label>
            <input type="email" id="txtEmail" name="txtEmail" placeholder="e.g thabo14@gmail.com" required />

            <label for="txtPassword">Account Password</label>
            <input type="password" id="txtPassword" name="txtPassword" required />

            <input type="submit" name="btnCapture" value="Login">
        </form>
    </div>

</div>
