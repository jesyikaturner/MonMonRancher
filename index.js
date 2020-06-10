'use strict';
import express from 'express';
import bodyParser from 'body-parser';
import path from 'path';

import breedTest from './src/breedingtest';

import routes from './src/routes/routes';

const app = express();
const PORT = process.env.PORT || 8080;

require('dotenv').config();
// example: let uriString = process.env.MONGOLAB_BLACK_URI || process.env.MONGO;
import mysql from 'mysql';
const pool = mysql.createPool({
    host: process.env.HOST,
    user: process.env.USER,
    password: process.env.PASSWORD,
    database: process.env.DATABASE,
    connectionLimit: 10,
    queueLimit: 0,
    enableKeepAlive: true
});

pool.on("connection", (connection) => {
  connection.on("err", (err) => {
    console.log("ERROR!");
  });
});

// bodyparser setup
app.use(bodyParser.urlencoded({extended: true}));
app.use(bodyParser.json());

// Use the built-in express middleware for serving static files
app.use(express.static('client'));


import sampleMonster from './src/data/sampleMonster';
let monster1 = JSON.parse(JSON.stringify(sampleMonster));
monster1.species = "cat";
monster1.elementGenetics = {
  "fire": 100.0,
  "water": 0.0,
  "wind": 0.0,
  "earth": 0.0,
  "light": 0.0,
  "shadow":0.0
};
monster1.attributeGenetics = {
  "health": 2,
  "mana": 1,
  "strength": 3,
  "agility": 2,
  "intellect": 1
};

let monster2 = JSON.parse(JSON.stringify(sampleMonster));
monster2.species = "cat";
monster2.elementGenetics = {
    "fire": 0.0,
    "water": 0.0,
    "wind": 100.0,
    "earth": 0.0,
    "light": 0.0,
    "shadow":0.0
};
monster2.attributeGenetics = {
  "health": 4,
  "mana": 3,
  "strength": 3,
  "agility": 2,
  "intellect": 5
};

//let test = breedTest(monster1, monster2);
let monster3 = breedTest(monster1, monster2);
console.log(monster3);
let monster4 = breedTest(monster3, monster1);
//console.log(breedTest(monster3, monster4));

routes(app);


app.get('/', (req, res) => {
  res.sendFile(path.join(__dirname + '/client/index.html'));
});

app.listen(PORT, () =>
  console.log(`your server is running on ${PORT}`)
);

export default app;
module.exports = { app };