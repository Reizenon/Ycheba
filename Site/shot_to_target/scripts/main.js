function main(event) {
    event.preventDefault();


    let isHuman = !document.getElementById('checkbox').checked;
    let x, y;
    if (isHuman) {
        x = Number(document.getElementById('inputX').value);
        y = Number(document.getElementById('inputY').value);
    }
    else {
        let scatterRadius = Number(document.getElementById('scatter-radius').value);
        let randxy = generateRandomCoordinates(scatterRadius);
        x = randxy.x;
        y = randxy.y;
    };
    document.getElementById('answer').textContent = "Баллы: " + shot(x, y)
};

function shot(x, y) {
    const checks = [
        { func: shotToPoint, score: 10 },
        { func: shotToHyperbola, score: 4 },
        { func: shotToRhombus, score: 3 },
        { func: shotToCircle, score: 2 },
        { func: shotToSquare, score: 1 },
    ];
    for (const { func, score } of checks) {
        if (func(x, y)) {
            return score
        };  
    }
    return 0
};

function generateRandomCoordinates(radius) {
    let theta = Math.random() * 2 * Math.PI;
    let r = Math.sqrt(Math.random()) * radius;
    let x = r * Math.cos(theta);
    let y = r * Math.sin(theta);
    return { x, y };
};

function shotToSquare(x, y) {
    return ((Math.abs(x) < 1) && (Math.abs(y) < 1))
};

function shotToCircle(x, y) {
    return ((x ** 2 + y ** 2) < 1)
};

function shotToRhombus(x, y) {
    return (Math.abs(x) + Math.abs(y) < 1)
};

function shotToHyperbola(x, y) {
    // return ((Math.abs(0.02/x)-Math.abs(y)) > 0)
    return Math.abs(y) <= (1 / (Math.abs(x) + (-1 + 5 ** 0.5) / 2) + (1 - 5 ** 0.5) / 2)
};

/**
 * @param {Number} x 
 * @param {Number} y 
 * @returns {boolean}
 */
function shotToPoint(x, y) {
    return (x === 0 && y === 0)
}

shotToPoint("", 1);
