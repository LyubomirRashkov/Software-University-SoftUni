function songs(input) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    let listOfSongs = [];

    for (let i = 1; i < input.length - 1; i++) {
        let [typeList, name, time] = input[i].split("_");

        let song = new Song(typeList, name, time);
        listOfSongs.push(song);
    }

    let targetTypeList = input[input.length - 1];

    if (targetTypeList === "all") {
        for (const song of listOfSongs) {
            console.log(song.name);
        }
    } else {
        let filteredSongs = listOfSongs.filter((s) => s.typeList === targetTypeList);

        for (const song of filteredSongs) {
            console.log(song.name);
        }
    }
}

songs(
    [3,
        'favourite_DownTown_3:14',
        'favourite_Kiss_4:16',
        'favourite_Smooth Criminal_4:01',
        'favourite']
);

songs(
    [4,
        'favourite_DownTown_3:14',
        'listenLater_Andalouse_3:24',
        'favourite_In To The Night_3:58',
        'favourite_Live It Up_3:48',
        'listenLater']
);

songs(
    [2,
        'like_Replay_3:15',
        'ban_Photoshop_3:48',
        'all']
);