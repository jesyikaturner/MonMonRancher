import Sequelize from 'sequelize';
require('dotenv').config();

const db = new Sequelize(process.env.DATABASE, process.env.USER, process.env.PASSWORD, 
{host: process.env.HOST, dialect: 'mysql', 
    pool:{
        max: 5,
        min: 0,
        acquire: 3000,
        idle: 10000
    }
});

export default db;