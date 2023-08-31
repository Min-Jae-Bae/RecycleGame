const express = require('express');
const router = express.Router();
const RecycleController = require('../controllers/recycle-controller');

router.get('/', RecycleController.findAllItems);    //  GET/item
//router.get('/:itemNo', RecycleController.findItemByItemNo); //  GET/item/1

module.exports = router;