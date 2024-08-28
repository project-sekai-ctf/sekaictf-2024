# Node.js environment
FROM node:21-alpine as deps

ENV LANG="C.UTF-8" PUPPETEER_SKIP_CHROMIUM_DOWNLOAD=true

WORKDIR /home/bot

COPY ./bot/*.json .

RUN npm install

COPY ./bot/ .

USER node

# PHP environment
FROM php:8.1-apache

# Install necessary APK packages for PHP environment
RUN apt update -y && apt install -y unzip wget
RUN apt install -y --no-install-recommends nodejs
RUN apt install -y --no-install-recommends zlib1g-dev udev ca-certificates chromium

WORKDIR /var/www/html

RUN curl -O https://raw.githubusercontent.com/wp-cli/builds/gh-pages/phar/wp-cli.phar && \
    chmod +x wp-cli.phar && \
    mv wp-cli.phar /usr/local/bin/wp

RUN chown www-data:www-data /var/www

USER www-data

RUN wp core download --path=/var/www/html/ --version=6.6.1

RUN cd /var/www/html/wp-content/plugins/ && wget https://downloads.wordpress.org/plugins/appmaker-woocommerce-mobile-app-manager.zip -O app.zip && unzip app.zip && rm app.zip
RUN cd /var/www/html/wp-content/plugins/ && wget https://downloads.wordpress.org/plugins/woocommerce.zip -O app.zip && unzip app.zip && rm app.zip
RUN cd /var/www/html/wp-content/plugins/ && wget https://downloads.wordpress.org/plugins/social-media-builder.zip -O app.zip && unzip app.zip && rm app.zip


USER root

RUN docker-php-ext-install mysqli \
    && docker-php-ext-enable mysqli

#install xdebug
# RUN pecl install xdebug \
    # && docker-php-ext-enable xdebug

COPY entrypoint.sh /entrypoint.sh
COPY ./wp-config.php ./wp-config.php
COPY ./.htaccess ./.htaccess
COPY ./conf.d/error_reporting.ini /usr/local/etc/php/conf.d/error_reporting.ini
RUN chmod +x /entrypoint.sh && \
    chmod 444 ./.htaccess /usr/local/etc/php/conf.d/error_reporting.ini
RUN sed -i 's/:80/:8080/' /etc/apache2/sites-available/000-default.conf && \
    sed -i 's/Listen 80/Listen 8080/' /etc/apache2/ports.conf

EXPOSE 8080

COPY /flag.txt /flag.txt
RUN mv /flag.txt /`cat /proc/sys/kernel/random/uuid`.txt

# Set ownership to root and make /var/www/html read-only
RUN chown root:root /var/www/html
RUN chmod -R 555 /var/www/html

USER www-data

COPY ./src/wp-content/plugins/a-plus-security /var/www/html/wp-content/plugins/a-plus-security
COPY ./src/db.php /var/www/html/wp-content/db.php


USER root
COPY ./conf.d/error_reporting.ini /usr/local/etc/php/conf.d/error_reporting.ini
COPY ./.htaccess /var/www/html/.htaccess
COPY --from=deps /home/bot /home/bot

ENTRYPOINT [ "/bin/bash", "/entrypoint.sh" ]
