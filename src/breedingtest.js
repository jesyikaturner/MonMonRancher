import sampleMonster from './data/sampleMonster';
import elementChart from './data/elementChart';

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
    let indexes = getHighestValues(childElements);
    newMonster.element = determineElement(indexes);

    // TODO: determine species
    // TODO: if incompatible then return null
    // TODO: determine attributes from parents
    // TODO: set image src to an egg picture

    newMonster.name = newMonster.element+" Egg";

    return newMonster;
}

const determineElement = (elements) => {
    let elementNames = Object.keys(sampleMonster.elementGenetics); 
    let element1 = "", element2 = "";

    if(elements.length < 2){
        element1 = element2 = elementNames[elements[0]];
    } else if(elements.length == 2){
        element1 = elementNames[elements[0]];
        element2 = elementNames[elements[1]];
    } else if(elements.length > 2){
        console.log("Monster has more than 2 types");
        // TODO: randomly choose 2, to choose element
    }

    for(var i = 0; i < elementChart.length; i++){
        if(element1 == elementChart[i].element1 && element2 == elementChart[i].element2){
            let r = elementChart[i].result;
            return r.charAt(0).toUpperCase()+r.substring(1);
        }
    }
}

const switchImage = (monster) => {

}

//https://stackoverflow.com/questions/55284833/javascript-return-all-indexes-of-highest-values-in-an-array
const getHighestValues = (array) => {
    let max = Math.max(...array);
    let indexes = [];
    array.forEach((item, index) => item === max ? indexes.push(index) : null);
    return indexes;
}

export default breedTest;