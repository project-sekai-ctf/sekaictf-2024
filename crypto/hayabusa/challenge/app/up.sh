git clone https://github.com/tprest/falcon.py.git

mv falcon.py falcon

echo "import os
import sys

sys.path.append(os.path.dirname(__file__))
" > ./falcon/__init__.py