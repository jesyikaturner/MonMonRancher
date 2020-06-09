# 1. Setup
This project requires [Node.js](https://nodejs.org/en/), [MySQL](https://www.mysql.com/).
1. Clone the repo.
```
    git clone https://github.com/jesyikaturner/MonMonRancher.git
```
2. Open the project in Command Prompt or Git Bash. Go to the cloned repo.
```
    cd MonMonRancher
```
3. Install application dependencies.
```
    npm install
```

## 1.1 Create Feature Branch
1. Create a feature branch based on user story and switch to it. The structure for feature branches is: `feature[001]-[descriptor]` where `[001]` is the number of the user story and the `[descriptor]` is a description of the user story.
```
    git checkout -b feature001-login
```
2. Work on project files.
3. Stage files for committing.
**Add all:**
```
    git add .
```
**Add specific files:**
``
    git add package.json app.js app.css
``
4. Commit files. Write a short description of what was done.
```
    git commit -m "Fixed some dependencies and added a nav bar to the front page."
```
5. Push commit to remote repo.
```
    git push -u -origin feature001-login
```

## 1.2 Work on Feature Branch
If the feature is already the working directory and exists. Just repeat instructions 2 - 4.
1. Push commit to remote repo.
```
    git push feature001-login
```

## 1.3 Setup MySQL Dev Environment
