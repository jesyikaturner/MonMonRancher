import sampleMonster from './data/sampleMonster';
import elementChart from './data/elementChart';
import species from './data/species';
import logger from './logging';

//https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Math/random
// This example returns a random integer between the specified values. 
// The value is no lower than min (or the next integer greater than min if min isn't an integer), 
// and is less than (but not equal to) max.
export const getRandomInt = (min, max) => {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min)) + min;
}

//https://stackoverflow.com/questions/55284833/javascript-return-all-indexes-of-highest-values-in-an-array
export const getHighestValueIndexes = (array) => {
    let max = Math.max(...array);
    let indexes = [];
    let string = "";
    array.forEach((item, index) => item === max ? indexes.push(index) : null);
    logger("getHighestValueIndexes", "Highest element value indexes found.");
    return indexes;
}

export const calculateAttributes = (monster) => {
    let speciesAtrributes = [];
    for(var i = 0; i < species.length; i++){
        if(monster.species.localeCompare(species[i].species)){
            speciesAtrributes = Object.values(species[i].speciesAtrributes);
        }
    }  
    // error checking
    if(speciesAtrributes.length < 1){
        return null;
    }

    monster.attributes.strength = calculateStat(speciesAtrributes[2],monster.attributeGenetics[2], monster.attributes.level,5);
    monster.attributes.agility = calculateStat(speciesAtrributes[3],monster.attributeGenetics[3], monster.attributes.level,5);
    monster.attributes.intellect = calculateStat(speciesAtrributes[4],monster.attributeGenetics[4], monster.attributes.level,5);
    monster.attributes.health = calculateStat(speciesAtrributes[0],monster.attributeGenetics[0], monster.attributes.level,monster.attributes.strength/2);
    monster.attributes.mana = calculateStat(speciesAtrributes[1],monster.attributeGenetics[1], monster.attributes.level,monster.attributes.intellect/2);
}

const calculateStat = (speciesBaseAttribute, geneticAttribute, level, bonus) => {
    return Math.ceil(2*(speciesBaseAttribute + geneticAttribute) * level / 100 + bonus);
}

export const randomGenetics = () => {
    let fire, water, wind, earth, light, shadow = 0;
    while((fire+water+wind+earth+light+shadow) != 100)
    {
        fire = getRandomInt(0,100);
        water = getRandomInt(0,100);
        wind = getRandomInt(0,100);
        earth = getRandomInt(0,100);
        light = getRandomInt(0,100);
        shadow = getRandomInt(0,100);
    }
    let array = [fire, water, wind, earth, light, shadow];
    return array;
}

export const determineElement = (elementIndexes, item) => {
    let elementNames = Object.keys(sampleMonster.elementGenetics); 
    let element1 = elementNames[elementIndexes[getRandomInt(0, elementIndexes.length)]];
    let element2 = elementNames[elementIndexes[getRandomInt(0, elementIndexes.length)]];

    for(var i = 0; i < elementChart.length; i++){
        if(element1 == elementChart[i].element1 && element2 == elementChart[i].element2 && item == elementChart[i].item){
            let r = elementChart[i].result;
            return r.charAt(0).toUpperCase()+r.substring(1);
        }
    }
}
