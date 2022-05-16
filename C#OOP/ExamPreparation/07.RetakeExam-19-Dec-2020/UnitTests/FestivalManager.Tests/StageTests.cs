// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
        private const string PerformerFirstName = "First name";
        private const string PerformerLastName = "Last name";
        private const string PerformerFullName = PerformerFirstName + " " + PerformerLastName;
        private const int PerformerAge = 20;
        private const string SongName = "Some song";

        private static TimeSpan songDuration = new TimeSpan(0, 3, 45);

        private Stage stage;
        private Performer performer;
        private Song song;

        [SetUp]
        public void Setup()
        {
            this.stage = new Stage();
            this.performer = new Performer(PerformerFirstName, PerformerLastName, PerformerAge);
            this.song = new Song(SongName, songDuration);
        }

        [Test]
        public void AddPerformer_ThrowsException_WhenGivenPerformerIsNull()
        {
            Assert.That(() => this.stage.AddPerformer(null), Throws.ArgumentNullException);
        }

        [Test]
        public void AddPerformer_ThrowsException_WhenGivenPerformerHasAgeLessThan18()
        {
            Performer youngPerformer = new Performer(PerformerFirstName, PerformerLastName, 10);

            Assert.That(() => this.stage.AddPerformer(youngPerformer), Throws.ArgumentException);
        }

        [Test]
        public void AddPerformer_WorksCorrectly_WhenDataIsValid()
        {
            Assert.That(this.stage.Performers.Count, Is.Zero);

            this.stage.AddPerformer(this.performer);

            Assert.That(this.stage.Performers.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddSong_ThrowsException_WhenGivenSongIsNull()
        {
            Assert.That(() => this.stage.AddSong(null), Throws.ArgumentNullException);
        }

        [Test]
        public void AddSong_ThrowsException_WhenGivenSongHasDurationLessThan1()
        {
            TimeSpan invalidDuration = new TimeSpan(0, 0, 45);

            Song shortSong = new Song(SongName, invalidDuration);

            Assert.That(() => this.stage.AddSong(shortSong), Throws.ArgumentException);
        }

        [Test]
        public void AddSongToPerformer_ThrowsException_WhenGivenSongNameIsNull()
        {
            this.stage.AddPerformer(this.performer);
            this.stage.AddSong(this.song);

            Assert.That(() => this.stage.AddSongToPerformer(null, this.performer.FullName), Throws.ArgumentNullException);
        }

        [Test]
        public void AddSongToPerformer_ThrowsException_WhenGivenPerformerNameIsNull()
        {
            Assert.That(() => this.stage.AddSongToPerformer(this.song.Name, null), Throws.ArgumentNullException);
        }

        [Test]
        public void AddSongToPerformer_ThrowsException_WhenThereIsNoPerformerWithTheGivenName()
        {
            this.stage.AddPerformer(this.performer);
            this.stage.AddSong(this.song);

            Assert.That(this.stage.Performers.Count, Is.EqualTo(1));
            Assert.That(() => this.stage.AddSongToPerformer(this.song.Name, "Fake performer"), Throws.ArgumentException);
        }

        [Test]
        public void AddSongToPerformer_ThrowsException_WhenThereIsNoSongWithTheGivenName()
        {
            this.stage.AddPerformer(this.performer);
            this.stage.AddSong(this.song);

            Assert.That(this.stage.Performers.Count, Is.EqualTo(1));
            Assert.That(() => this.stage.AddSongToPerformer("Fake song", this.performer.FullName), Throws.ArgumentException);
        }

        [Test]
        public void AddSongToPerformer_WorksCorrectly_WhenDataIsValid()
        {
            this.stage.AddPerformer(this.performer);
            this.stage.AddSong(this.song);

            string expected = $"{this.song.Name} ({this.song.Duration:mm\\:ss}) will be performed by {this.performer.FullName}";

            string actual = this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Play_WorksCorrectly()
        {
            string songName1 = "Some song1";
            TimeSpan duration1 = new TimeSpan(0, 3, 15);

            Song song1 = new Song(songName1, duration1);
            this.stage.AddSong(song1);

            string songName2 = "Some song2";
            TimeSpan duration2 = new TimeSpan(0, 2, 45);

            Song song2 = new Song(songName2, duration2);
            this.stage.AddSong(song2);

            string performer1FirstName = "First name1";
            string performer1LastName = "Last name1";
            string performer1FullName = performer1FirstName + " " + performer1LastName;

            Performer performer1 = new Performer(performer1FirstName, performer1LastName, 25);
            this.stage.AddPerformer(performer1);

            string performer2FirstName = "First name2";
            string performer2LastName = "Last name2";
            string performer2FullName = performer2FirstName + " " + performer2LastName;

            Performer performer2 = new Performer(performer2FirstName, performer2LastName, 35);
            this.stage.AddPerformer(performer2);

            this.stage.AddSongToPerformer(songName1, performer1FullName);
            this.stage.AddSongToPerformer(songName2, performer1FullName);

            string expected = "2 performers played 2 songs";

            string actual = this.stage.Play();

            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}