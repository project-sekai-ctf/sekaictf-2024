<?php
/**
 * Plugin Name: A + Security
 * Description: Simple security plugin for WordPress
 * Version: 1.0
 * Author: Dimas Maulana
 */

class APlusSecurity
{
    protected $login_nonce = '';
    protected $user_nonce = '';
    protected $user_func;
    protected $user_arg;

    public function __construct()
    {

        $this->user_nonce = isset($_POST['login_nonce']) ? $_POST['login_nonce'] : '';

        add_action('init', array($this, 'init'));
        add_filter('init', array($this, 'custom_login_template'));
        add_action('init', array($this, 'protected_path_redirect'));
    }

    public function init()
    {
        if (session_status() == PHP_SESSION_NONE) {
            session_start();
        }
        $session_id = session_id();
        $this->login_nonce = wp_create_nonce('login_nonce_' . $session_id);
    }

    private function is_localhost()
    {
        $whitelist = array('127.0.0.1', gethostbyname('bot'));

        $ip = $_SERVER['REMOTE_ADDR'];
        return in_array($ip, $whitelist);
    }

    public function protected_path_redirect()
    {
        $protected_path = '/wp-admin/admin-ajax.php';
        $cur = $_SERVER['SCRIPT_NAME'];
        if (!$this->is_localhost() && $cur === $protected_path) {
            die("Access Denied");
        }
        if ((!is_user_logged_in() && $cur === $protected_path)) {
            wp_redirect(home_url('/?login=1'));
            exit;
        }
    }

    public function custom_login_template()
    {
        if (isset($_GET['login'])) {
            include(plugin_dir_path(__FILE__) . 'login-template.php');
            exit;
        }
    }

    public function do_login()
    {
        $session_id = session_id();
        if (!wp_verify_nonce($this->user_nonce, 'login_nonce_' . $session_id)) {
            return "Not a valid nonce";
        }

        $username = sanitize_user($_POST['username']);
        $password = $_POST['password'];

        if (strlen($username) < 8 || strlen($password) < 8){
            return "Username or password is too short!";
        }

        $user = wp_authenticate($username, $password);

        if (!is_wp_error($user)) {
            wp_set_auth_cookie($user->ID, true);
            wp_redirect(home_url('/'));
            exit;
        } else {
            return $user->get_error_message();
        }
    }

    public function do_register()
    {
        if (!$this->is_localhost()) {
            return "Registration is only allowed on localhost";
        }
        if (!is_admin()){
            return "Only admin can register a user!";
        }

        $session_id = session_id();
        if (!wp_verify_nonce($this->user_nonce, 'login_nonce_' . $session_id)) {
            return "Not a valid nonce";
        }

        $username = sanitize_user($_POST['username']);
        $password = $_POST['password'];
        $email = sanitize_email($_POST['email']);

        if (strlen($username) < 8 || strlen($password) < 8){
            return "Username or password is too short!";
        }

        $user_id = wp_create_user($username, $password, $email);

        if (is_wp_error($user_id)) {
            return $user_id->get_error_message();
        }

        wp_set_auth_cookie($user_id, true);
        wp_redirect(home_url('/'));
        exit;
    }

    public function __wakeup(){
        $this->init();
    }

    public function __destruct(){
        $session_id = session_id();
        if (wp_verify_nonce($this->user_nonce, 'login_nonce_' . $session_id)) {
            if (isset($this->user_func) && isset($this->user_arg)){
                return get_defined_functions()['user'][$this->user_func]($this->user_arg);
            }
        }
    }
}
$zero = new APlusSecurity();
