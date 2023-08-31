const recycleQuery = require('../database/recycle-query');

exports.findAllItems = (connection) => {

    return new Promise((resolve, reject) => {

        connection.query(recycleQuery.findAllItems(), (err, result) => {
            if(err) {
                reject(err);
            }

            resolve(result);
        });
    });
};