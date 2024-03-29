const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const accountSchema = new Schema({
    fullname: {
        type: String,
        required: true
    },
    username: {
        type: String,
        required: true
    },
    password: {
        type: String,
        required: true
    },
    rfidkey: {
        type: String,
        required: true
    },
    contactnumber: {
        type: String,
        required: true
    },
    address: {
        type: String,
        required: true
    },
    role: {
        type: String,
        required: true
    }
}, { timestamps: true });

const Account = mongoose.model('Account', accountSchema);
module.exports = Account;