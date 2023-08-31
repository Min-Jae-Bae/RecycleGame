const express = require('express');
const morgan = require('morgan');

const app = express();

app.use(morgan('dev'));
app.use(express.json());

const recycleRouter = require('./src/routes/recycle-route');
app.use('/item', recycleRouter);

app.listen(8888, () => console.log('listening on port 8888'));