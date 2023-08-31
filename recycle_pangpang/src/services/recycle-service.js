const getConnection = require('../database/connection');
const RecycleRepository = require('../repositories/recycle-repo');

exports.findAllItems = () => {

    return new Promise((resolve, reject) => {

        const connection = getConnection();

        const results = RecycleRepository.findAllItems(connection);

        connection.end();

        resolve(results);
    });
}