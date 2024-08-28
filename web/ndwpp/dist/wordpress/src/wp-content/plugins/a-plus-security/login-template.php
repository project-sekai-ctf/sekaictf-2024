<?php

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    if (isset($_POST['action']) && $_POST['action'] === "login") {
        $error_message = $this->do_login();
    } elseif (isset($_POST['action']) && $_POST['action'] === "register") {
        $error_message = $this->do_register();
    }
}

?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Custom Login</title>
</head>

<body>

    <h2>Custom Login</h2>

    <?php if (isset($error_message)) : ?>
        <p style="color: red;"><?php echo $error_message; ?></p>
    <?php endif; ?>

    <?php if (!isset($_GET['register'])): ?>
        <!-- Login Form -->
        <form method="post">
            <label for="username">Username:</label>
            <input type="text" name="username" id="username" required>
            <br>
            <label for="password">Password:</label>
            <input type="password" name="password" id="password" required>
            <br>
            <input type="hidden" name="action" value="login"> <!-- Added action field -->
            <input type="hidden" name="login_nonce" value="<?= $this->login_nonce ?>">
            <input type="submit" value="Login">
        </form>

        <!-- Registration Link/Button -->
        <p>Don't have an account? <a href="?login&register=1">Register</a></p>
    <?php else : ?>
        <!-- Registration Form -->
        <form method="post">
            <label for="username">Username:</label>
            <input type="text" name="username" id="username" required>
            <br>
            <label for="password">Password:</label>
            <input type="password" name="password" id="password" required>
            <br>
            <label for="email">Email:</label>
            <input type="email" name="email" id="email" required>
            <br>
            <input type="hidden" name="action" value="register">
            <input type="hidden" name="login_nonce" value="<?= $this->login_nonce ?>">
            <input type="submit" value="Register">
        </form>

        <!-- Login Link/Button -->
        <p>Already have an account? <a href="?login">Login</a></p>
    <?php endif; ?>

</body>

</html>
