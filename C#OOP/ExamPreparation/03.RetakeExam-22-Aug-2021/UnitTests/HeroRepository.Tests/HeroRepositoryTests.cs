using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private const string HeroName = "Some name";
    private const int HeroLevel = 10;

    private HeroRepository heroRepository;
    private Hero hero;

    [SetUp]
    public void Setup()
    {
        this.heroRepository = new HeroRepository();
        this.hero = new Hero(HeroName, HeroLevel);
    }

    [Test]
    public void Constructor_CreatesAnEmptyCollection()
    {
        Assert.That(this.heroRepository.Heroes.Count, Is.Zero);
    }

    [Test]
    public void Create_ThrowsException_WhenHeorIsNull()
    {
        Assert.That(() => this.heroRepository.Create(null), Throws.ArgumentNullException);
    }

    [Test]
    public void Create_ThrowsException_WhenThereIsAHeroWithTheGivenName()
    {
        this.heroRepository.Create(this.hero);

        Hero hero2 = new Hero(HeroName, HeroLevel + 5);

        Assert.That(() => this.heroRepository.Create(hero2), Throws.InvalidOperationException);
    }

    [Test]
    public void Create_WorksCorrectly_WhenDataIsValid()
    {
        Assert.That(this.heroRepository.Heroes.Count, Is.Zero);

        string expected = $"Successfully added hero {HeroName} with level {HeroLevel}";

        string actual = this.heroRepository.Create(this.hero);

        Assert.That(this.heroRepository.Heroes.Count, Is.EqualTo(1));
        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void Remove_ThrowsException_WhenGivenNameIsNullEmptyOrWhitesSpace(string name)
    {
        this.heroRepository.Create(this.hero);

        Assert.That(() => this.heroRepository.Remove(name), Throws.ArgumentNullException);
    }

    [Test]
    public void Remove_ReturnsTrue_WhenTheRemovalIsSuccessfull()
    {
        this.heroRepository.Create(this.hero);

        Assert.That(this.heroRepository.Heroes.Count, Is.EqualTo(1));

        bool result = this.heroRepository.Remove(HeroName);

        Assert.That(this.heroRepository.Heroes.Count, Is.Zero);
        Assert.That(result, Is.True);
    }

    [Test]
    public void Remove_ReturnsFalse_WhenTheRemovalIsNotSuccessfull()
    {
        this.heroRepository.Create(this.hero);

        Assert.That(this.heroRepository.Heroes.Count, Is.EqualTo(1));

        bool result = this.heroRepository.Remove("Fake name");

        Assert.That(this.heroRepository.Heroes.Count, Is.EqualTo(1));
        Assert.That(result, Is.False);
    }

    [Test]
    public void GetHeroWithHighestLevel_ReturnsTheHeroWithHighestLevel()
    {
        this.heroRepository.Create(this.hero);

        Hero hero2 = new Hero("Name 2", HeroLevel + 5);
        this.heroRepository.Create(hero2);

        Hero hero3 = new Hero("Name 3", HeroLevel + 10);
        this.heroRepository.Create(hero3);

        Hero bestHero = this.heroRepository.GetHeroWithHighestLevel();

        Assert.That(hero3, Is.EqualTo(bestHero));
    }

    [Test]
    public void GetHeroWithHighestLevel_ThrowsException_WhenTheCollectionIsEmpty()
    {
        Assert.Throws<IndexOutOfRangeException>(() => this.heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHero_ReturnsNull_WhenThereIsNotHeroWithTheGivenName() 
    {
        this.heroRepository.Create(this.hero);

        Hero returnedHero = this.heroRepository.GetHero("Fake name");

        Assert.That(returnedHero, Is.Null);
    }

    [Test]
    public void GetHero_ReturnsTheCorrectHero_WhenThereIsAHeroWithTheGivenName()
    {
        this.heroRepository.Create(this.hero);

        Hero returnedHero = this.heroRepository.GetHero(HeroName);

        Assert.That(returnedHero, Is.EqualTo(this.hero));
    }
}