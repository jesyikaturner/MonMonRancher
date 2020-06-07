import fs from 'fs';
import { DateTime } from 'luxon';

const logger = (func, msg) => {
    //https://moment.github.io/luxon/docs/manual/formatting.html#toformat
    var now = DateTime.local().toFormat('ff');
    let data = `[${now}] ${func}: ${msg}\n`;

    fs.writeFile('log.txt', data, {flag:'a'}, (err) => {
        if(err){
            console.log("Error with log.");
        }
    })
}

export default logger;