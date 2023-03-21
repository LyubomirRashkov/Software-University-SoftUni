function solver(numberAsString, ...operations) {
    let number = Number(numberAsString);

    for (const operation of operations) {
        switch (operation) {
            case "chop":
                number /= 2;
                console.log(number);
                break;

            case "dice":
                number = Math.sqrt(number);
                console.log(number);
                break;
            
            case "spice":
                number += 1;
                console.log(number);
                break;

            case "bake":
                number *= 3;
                console.log(number);
                break;

            case "fillet":
                number *= 0.8;
                console.log(number);
                break;
        }
    }
}