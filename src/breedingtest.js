import sampleMonster from './data/sampleMonster';
import species from './data/species';

import sampleMonMon from './data/sampleMonMon';

import { getRandomInt, getHighestValueIndexes, 
    calculateAttributes, determineElement, randomGenetics } from './shared';

import logger from './logging';

const breedPrototypeMonster = (mother, father) => {
    logger("breedPrototypeMonster", "Creating an empty child by cloning the sample.");
    let newMon = JSON.parse(JSON.stringify(sampleMonMon));

    logger("breedPrototypeMonster", "Getting the geneticElements.");
    let childGeneticElements = Object.values(newMon.geneticElements);
    let motherGeneticElements = Object.values(mother.geneticElements);
    let fatherGeneticElements = Object.values(father.geneticElements);

    logger("breedPrototypeMonster", "Giving child 50% from each parent.");
    for(var i=0; i < Object.keys(newMon.geneticElements).length; i++)
    {
        childGeneticElements[i] = (motherGeneticElements[i] * 0.5) + (fatherGeneticElements[i] * 0.5)
    }
    newMon.geneticElements = childGeneticElements;

    logger("breedPrototypeMonster", "Determining element from genetics.");
    let indexes = getHighestValueIndexes(childElements);
    newMon.element = determineElement(indexes, "");
    logger("breedPrototypeMonster", `Child MonMon's element is ${newMon.element}.`);

    logger("breedPrototypeMonster", "Checking both parent's species are valid species!");
    let parentSpecies = [];
    for(var i = 0; i < species.length; i++)
    {
        if(mother.species.localeCompare(species[i].species))
        {
            parentSpecies.push(mother.species);
        }
        if(father.species.localeCompare(species[i].species))
        {
            parentSpecies.push(father.species);
        }
    }
    if(parentSpecies.length < 1){
        logger("breedPrototypeMonster", "ERROR! Only one valid parent species in array!");
        return null;
    }
    logger("breedPrototypeMonster", `PASSED! ${parentSpecies}`);

    newMon.species = parentSpecies[getRandomInt(0,parentSpecies.length)];
    logger("breedPrototypeMonster", `Child MonMon's species is ${newMon.species}.`);

    logger("breedPrototypeMonster","Checking Child MonMon's species is compatiable with element.");
    for(var i = 0; i < species.length; i++)
    {
        for(var x = 0; x < species[i].elements.length; x++)
        {
            if(newMonster.element.localeCompare(species[i].elements[x]))
            {
                logger("breedPrototypeMonster","PASSED! Child's species is compatiable with element!");
            }else
            {
                logger("breedPrototypeMonster","Error! Child's species is incompatiable with element!");
                return null;
            }
        }
    }




}

// TODO: Generate 3 potential offsprings
const breedTest = (mon1, mon2) => {
    let newMonster = JSON.parse(JSON.stringify(sampleMonster));

    // determine elemental genetics
    let childElements = Object.values(newMonster.elementGenetics);
    let mon1Elements = Object.values(mon1.elementGenetics);
    let mon2Elements = Object.values(mon2.elementGenetics);

    // children get 50% of each stat from the parents then added together
    for(var i = 0; i < Object.keys(sampleMonster.elementGenetics).length; i++){
        childElements[i] = mon1Elements[i]*0.50+mon2Elements[i]*0.50;
    }
    newMonster.elementGenetics = childElements;

    // determine element from genetics
    let indexes = getHighestValueIndexes(childElements);
    newMonster.element = determineElement(indexes, "");

    // TODO: determine species
    let parentSpecies = [];
    for(var i = 0; i < species.length; i++){
        if(mon1.species.localeCompare(species[i].species)){
            parentSpecies.push(mon1.species);
        }
        if(mon2.species.localeCompare(species[i].species)){
            parentSpecies.push(mon2.species);
        }
    }
    console.log(parentSpecies);
    if(parentSpecies.length < 1){
        // TODO: Log error
        return null;
    }

    newMonster.species = parentSpecies[getRandomInt(0,parentSpecies.length)];


    // determine attributes from parents
    let childGenetics = Object.values(newMonster.attributeGenetics);
    let mon1Genetics = Object.values(mon1.attributeGenetics);
    let mon2Genetics = Object.values(mon2.attributeGenetics);
    for(var i = 0; i < Object.keys(sampleMonster.attributeGenetics).length; i++){
        if(mon1Genetics[i]+1 > mon2Genetics[i]){
            childGenetics[i] = getRandomInt(mon2Genetics[i], mon1Genetics[i]+1);
        }else if (mon2Genetics[i]+1 > mon1Genetics[i]){
            childGenetics[i] = getRandomInt(mon1Genetics[i], mon2Genetics[i]+1);
        }
    }
    newMonster.attributeGenetics = childGenetics;
    newMonster.attributes.level = 100;

    // calculate stats
    calculateAttributes(newMonster);


    // TODO: set image src to an egg picture

    newMonster.name = `${newMonster.element} Egg`;

    return newMonster;
}



export default breedTest;