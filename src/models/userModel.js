import Sequelize from 'sequelize';
import db from '../database';

const User = db.define('User', {
    uid: { 
        type: Sequelize.STRING,
        primaryKey: true,
        allowNull: false
    },
    email: {
        type: Sequelize.STRING
    },
    nickname: {
        type: Sequelize.STRING
    }
});

export default User;