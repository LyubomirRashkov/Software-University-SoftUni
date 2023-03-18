function solver(parameter) {
    let parameterType = typeof(parameter);

    let output = "";

    if (parameterType === "number") {
        output = (Math.PI * (parameter ** 2)).toFixed(2);
    } else {
        output = `We can not calculate the circle area, because we receive a ${parameterType}.`;
    }

    console.log(output);
}