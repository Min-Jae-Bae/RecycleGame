const mysql = require('mysql');
const connectionInfo = require('../config/db-config.js');

const getConnection = () => {

    return mysql.createConnection(connectionInfo);
}

module.exports = getConnection;