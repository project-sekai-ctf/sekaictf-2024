#!/bin/bash

apache2-foreground &

(
    cd /home/bot
    while true; do
        node index.js
    done
) &

# Function to check if the host is up
is_host_up() {
    local url="http://localhost:8080"
    local response=$(curl -s -o /dev/null -w "%{http_code}" "$url")
    if [ "$response" != "000" ]; then
        echo "Host is up"
        return 0
    else
        echo "Host is down. Restarting in 1 seconds..."
        return 1
    fi
}


# Check if the host is up
while ! is_host_up; do
    sleep 1
done

WP_ADMIN_USER=`cat /proc/sys/kernel/random/uuid`
WP_ADMIN_PASSWORD=`cat /proc/sys/kernel/random/uuid`

echo "Username: $WP_ADMIN_USER"
echo "Password: $WP_ADMIN_PASSWORD"

while ! (su -l www-data -s /bin/bash <<< "wp core install --path='/var/www/html' --url='$WP_HOST' --title='$WP_TITLE' --admin_user='$WP_ADMIN_USER' --admin_password='$WP_ADMIN_PASSWORD' --admin_email='$WP_ADMIN_EMAIL'"); do
    echo "Trying to install wordpress..."
    sleep 1
done

# wp plugin install <plugin zip to install>
su -l www-data -s /bin/bash <<< "wp plugin --path='/var/www/html' activate a-plus-security social-media-builder woocommerce appmaker-woocommerce-mobile-app-manager"

sleep infinity
