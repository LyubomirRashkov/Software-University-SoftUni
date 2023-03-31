function movies(input) {
    let listOfMovies = [];

    for (const element of input) {
        let tokens = element.split(" ");

        let name = "";

        if (tokens[0] === "addMovie") {
            name = tokens.slice(1).join(" ");

            addMovie(name);
        } else if (tokens.indexOf("directedBy") !== -1) {
            let index = tokens.indexOf("directedBy");

            name = tokens.slice(0, index).join(" ");
            let director = tokens.slice(index + 1).join(" ");

            addDirector(name, director);
        } else {
            let index = tokens.indexOf("onDate");

            name = tokens.slice(0, index).join(" ");
            let date = tokens.slice(index + 1).join(" ");
            
            addDate(name, date);
        }
    }

    listOfMovies
        .filter((m) => m.hasOwnProperty("director") && m.hasOwnProperty("date"))
        .forEach((m) => console.log(JSON.stringify(m)));

    function addMovie(name) {
        let movie = { name };

        listOfMovies.push(movie);
    }

    function addDirector(name, director) {
        let movie = listOfMovies.find((m) => m.name === name);

        if (movie) {
            movie["director"] = director;
        }
    }

    function addDate(name, date) {
        let movie = listOfMovies.find((m) => m.name === name);

        if (movie) {
            movie["date"] = date;
        }
    }
}

movies(
    [
        'addMovie Fast and Furious',
        'addMovie Godfather',
        'Inception directedBy Christopher Nolan',
        'Godfather directedBy Francis Ford Coppola',
        'Godfather onDate 29.07.2018',
        'Fast and Furious onDate 30.07.2018',
        'Batman onDate 01.08.2018',
        'Fast and Furious directedBy Rob Cohen'
    ]
);

movies(
    [
        'addMovie The Avengers',
        'addMovie Superman',
        'The Avengers directedBy Anthony Russo',
        'The Avengers onDate 30.07.2010',
        'Captain America onDate 30.07.2010',
        'Captain America directedBy Joe Russo'
    ]
);