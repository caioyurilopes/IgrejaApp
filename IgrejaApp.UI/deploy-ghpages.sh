dotnet publish IgrejaApp.UI -c Release -o dist

cd dist/wwwroot
git init
git remote add origin https://github.com/caioyurilopes/IgrejaApp.git
git checkout -b gh-pages
git add .
git commit -m "deploy"
git push origin gh-pages --force
cd ../../..