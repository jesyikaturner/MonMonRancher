'use strict';

import express from 'express';
import bodyParser from 'body-parser';
import path from 'path';

import breedTest from './src/breedingtest';

const app = express();
const PORT = process.env.PORT || 8080;

require('dotenv').config();
// example: let uriString = process.env.MONGOLAB_BLACK_URI || process.env.MONGO;
import mysql from 'mysql';
const connection = mysql.createConnection({
    host: process.env.HOST,
    user: process.env.USER,
    password: process.env.PASSWORD,
    database: process.env.DATABASE
});

//connection.connect((err) => {
//    if(err) throw err;
//    console.log("Connected!");
//})

// bodyparser setup
app.use(bodyParser.urlencoded({extended: true}));
app.use(bodyParser.json());

// Use the built-in express middleware for serving static files
app.use(express.static('client'));


import sampleMonster from './src/data/sampleMonster';
let monster1 = JSON.parse(JSON.stringify(sampleMonster));
monster1.elementGenetics = {
    "fire": 100.0,
    "water": 0.0,
    "wind": 0.0,
    "earth": 0.0,
    "light": 0.0,
    "shadow":0.0
};

let monster2 = JSON.parse(JSON.stringify(sampleMonster));
monster2.elementGenetics = {
    "fire": 0.0,
    "water": 0.0,
    "wind": 100.0,
    "earth": 0.0,
    "light": 0.0,
    "shadow":0.0
};
//let test = breedTest(monster1, monster2);
let monster3 = breedTest(monster1, monster2);
let monster4 = breedTest(monster3, monster1);
console.log(breedTest(monster3, monster4));





app.get('/', (req, res) => {
  res.sendFile(path.join(__dirname + '/client/index.html'));
});

app.listen(PORT, () =>
  console.log(`your server is running on ${PORT}`)
);

export default app;
module.exports = { app };