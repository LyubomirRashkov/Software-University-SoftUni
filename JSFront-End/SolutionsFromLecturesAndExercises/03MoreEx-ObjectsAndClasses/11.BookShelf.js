function bookShelf(input) {
    let shelves =[];

    for (const element of input) {
        if (element.includes("->")) {
            let [shelfId, shelfGenre] = element.split(" -> ");

            let shelf = shelves.find((s) => s.id === shelfId);

            if (!shelf) {
                shelf = {
                    id: shelfId,
                    genre: shelfGenre,
                    books: [],
                };

                shelves.push(shelf);
            }
        } else {
            let [bookTitle, authorAndGenre] = element.split(": ");
            let [bookAuthor, bookGenre] = authorAndGenre.split(", ");

            let shelf = shelves.find((s) => s.genre === bookGenre);

            if (shelf) {
                let book = {
                    title: bookTitle,
                    author: bookAuthor,
                };

                shelf.books.push(book);
            }
        }
    }

    let sortedShelves = shelves.sort((a, b) => b.books.length - a.books.length);

    for (const shelf of sortedShelves) {
        console.log(`${shelf.id} ${shelf.genre}: ${shelf.books.length}`);

        let sortedBooks = shelf.books.sort((a, b) => a.title.localeCompare(b.title));

        for (const book of sortedBooks) {
            console.log(`--> ${book.title}: ${book.author}`);
        }
    }
}

bookShelf(
    [
        '1 -> history',
        '1 -> action',
        'Death in Time: Criss Bell, mystery',
        '2 -> mystery',
        '3 -> sci-fi',
        'Child of Silver: Bruce Rich, mystery',
        'Hurting Secrets: Dustin Bolt, action',
        'Future of Dawn: Aiden Rose, sci-fi',
        'Lions and Rats: Gabe Roads, history',
        '2 -> romance',
        'Effect of the Void: Shay B, romance',
        'Losing Dreams: Gail Starr, sci-fi',
        'Name of Earth: Jo Bell, sci-fi',
        'Pilots of Stone: Brook Jay, history'
    ]
);

bookShelf(
    [
        '1 -> mystery',
        '2 -> sci-fi',
        'Child of Silver: Bruce Rich, mystery',
        'Lions and Rats: Gabe Roads, history',
        'Effect of the Void: Shay B, romance',
        'Losing Dreams: Gail Starr, sci-fi',
        'Name of Earth: Jo Bell, sci-fi'
    ]
);