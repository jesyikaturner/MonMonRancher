import logger from './logging';
import sampleMonMon from './data/sampleMonMon';
import { getRandomInt, getHighestValueIndexes, 
    calculateAttributes, determineElement, randomGenetics } from './shared';

const generateMon = () =>
{
    logger("generateMon", "Creating an empty monster by cloning the sample.");
    let newMon = JSON.parse(JSON.stringify(sampleMonMon));



    return newMon;
}

const breedPrototypeMonster = (mother, father) => {
    logger("breedPrototypeMonster", "Creating an empty monster by cloning the sample.");
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

    newMonster.species = parentSpecies[getRandomInt(0,parentSpecies.length)];
}