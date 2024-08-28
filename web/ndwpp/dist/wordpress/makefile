install-wordpress:
	(wp core download --path=./src || true) && \
	cp ./wp-config.php ./src/wp-config.php
clean-install:
	docker-compose down --volumes && docker-compose up --build

copy-wp-from-container:
	docker-compose cp wordpress:/var/www/html/ ./html/
