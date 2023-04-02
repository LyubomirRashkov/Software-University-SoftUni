function commentsSolver(input) {
    let usernames = [];
    let articles = [];

    for (const element of input) {
        if (element.includes("posts on")) {
            let [postingInfo, commentInfo] = element.split(": ");

            let[username, articleName] = postingInfo.split(" posts on ");

            let article = articles.find((a) => a.name === articleName);

            if (usernames.includes(username) && article) {
                let [commentTitle, commentContent] = commentInfo.split(", ");

                let comment = {
                    title: commentTitle,
                    content: commentContent,
                    author: username,
                };

                article.comments.push(comment);
            }
        } else if (element.includes("user")) {
            let tokens = element.split(" ");
            tokens.shift();

            let username = tokens.join(" ");

            usernames.push(username);
        } else {
            let tokens = element.split(" ");
            tokens.shift();

            let articleName = tokens.join(" ");

            let article = {
                name: articleName,
                comments: [],
            };

            articles.push(article);
        }
    }

    let sortedArticles = articles.sort((a, b) => b.comments.length - a.comments.length);

    for (const article of sortedArticles) {
        console.log(`Comments on ${article.name}`);

        let sortedComments = article.comments.sort((a, b) => a.author.localeCompare(b.author));

        for (const comment of sortedComments) {
            console.log(`--- From user ${comment.author}: ${comment.title} - ${comment.content}`);
        }
    }
}

commentsSolver(
    [
        'user aUser123',
        'someUser posts on someArticle: NoTitle, stupidComment',
        'article Books',
        'article Movies',
        'article Shopping',
        'user someUser',
        'user uSeR4',
        'user lastUser',
        'uSeR4 posts on Books: I like books, I do really like them',
        'uSeR4 posts on Movies: I also like movies, I really do',
        'someUser posts on Shopping: title, I go shopping every day',
        'someUser posts on Movies: Like, I also like movies very much'
    ]
);

commentsSolver(
    [
        'user Mark',
        'Mark posts on someArticle: NoTitle, stupidComment',
        'article Bobby',
        'article Steven',
        'user Liam',
        'user Henry',
        'Mark posts on Bobby: Is, I do really like them',
        'Mark posts on Steven: title, Run',
        'someUser posts on Movies: Like'
    ]
);