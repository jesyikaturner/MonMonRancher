import sampleMonster from './data/sampleMonster';
import { getRandomInt, getHighestValueIndexes, 
    calculateAttributes, determineElement } from './shared';

// TODO: Generate 3 potential offsprings
const breedTest = (mon1, mon2) => {
    let newMonster = JSON.parse(JSON.stringify(sampleMonster));

    // TODO: check parent's parents to make sure they aren't directly related

    // TODO: set parents, set siblings

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
    // TODO: if incompatible then return null

    // determine attributes from parents
    let childGenetics = Object.values(newMonster.geneticAtrributes);
    let mon1Genetics = Object.values(mon1.geneticAtrributes);
    let mon2Genetics = Object.values(mon2.geneticAtrributes);
    for(var i = 0; i < Object.keys(sampleMonster.geneticAtrributes).length; i++){
        if(mon1Genetics[i]+1 > mon2Genetics[i]){
            childGenetics[i] = getRandomInt(mon2Genetics[i], mon1Genetics[i]+1);
        }else if (mon2Genetics[i]+1 > mon1Genetics[i]){
            childGenetics[i] = getRandomInt(mon1Genetics[i], mon2Genetics[i]+1);
        }
    }
    newMonster.geneticAtrributes = childGenetics;

    // calculate stats
    calculateAttributes(newMonster);


    // TODO: set image src to an egg picture

    newMonster.name = newMonster.element+" Egg";

    return newMonster;
}



export default breedTest;