using PhotoAlbum;
using System;
using Xunit;

namespace TestPhotoAlbum
{
    public class UnitTest1
    {
        [Fact]
        public void TestValidObjectPhoto()
        {
            // ARRANGE
            Photo photo = new Photo(1, 2, "Title", "Url", "ThumbnailUrl");

            // ACT
            int expectedalbumId = 1;
            int expectedid = 2;
            string expectedtitle = "Title";
            string expectedurl = "Url";
            string expectedthumnailUrl = "ThumbnailUrl";

            // ASSERT
            Assert.Equal(photo.albumId, expectedalbumId);
            Assert.Equal(photo.id, expectedid);
            Assert.Equal(photo.title, expectedtitle);
            Assert.Equal(photo.url, expectedurl);
            Assert.Equal(photo.thumbnailUrl, expectedthumnailUrl);
        }

        [Fact]
        public void TestSentinelTruex()
        {
            // ARRANGE
            string input = "x";
            bool sentinel;
            bool expected;

            // ACT
            sentinel = Validation.Sentinel(input);
            expected = true;

            // ASSERT
            Assert.Equal(sentinel, expected);
        }

        [Fact]
        public void TestSentinelTrueX()
        {
            // ARRANGE
            string input = "X";
            bool sentinel;
            bool expected;

            // ACT
            sentinel = Validation.Sentinel(input);
            expected = true;

            // ASSERT
            Assert.Equal(sentinel, expected);
        }

        [Fact]
        public void TestSentinelFalse()
        {
            // ARRANGE
            string input = "X";
            bool sentinel;
            bool expected;

            // ACT
            sentinel = Validation.Sentinel(input);
            expected = true;

            // ASSERT
            Assert.Equal(sentinel, expected);
        }

        [Fact]
        public void TestValidateTrueInt()
        {
            // ARRANGE
            string input = "1";
            bool validate;
            bool expected;

            // ACT
            validate = Validation.Validate(input);
            expected = true;

            // ASSERT
            Assert.Equal(validate, expected);
        }

        [Fact]
        public void TestValidateFalseInt()
        {
            // ARRANGE
            string input = "abc";
            bool validate;
            bool expected;

            // ACT
            validate = Validation.Validate(input);
            expected = false;

            // ASSERT
            Assert.Equal(validate, expected);
        }

        [Fact]
        public void TestValidateTrueRange()
        {
            // ARRANGE
            string input = "50";
            bool validate;
            bool expected;

            // ACT
            validate = Validation.Validate(input);
            expected = true;

            // ASSERT
            Assert.Equal(validate, expected);
        }

        [Fact]
        public void TestValidateFalseRangeLow()
        {
            // ARRANGE
            string input = "-1";
            bool validate;
            bool expected;

            // ACT
            validate = Validation.Validate(input);
            expected = false;

            // ASSERT
            Assert.Equal(validate, expected);
        }

        [Fact]
        public void TestValidateFalseRangeHigh()
        {
            // ARRANGE
            string input = "101";
            bool validate;
            bool expected;

            // ACT
            validate = Validation.Validate(input);
            expected = false;

            // ASSERT
            Assert.Equal(validate, expected);
        }

        [Fact]
        public void TestReadAlbumSuccess()
        {
            // ARRANGE
            string url = "https://jsonplaceholder.typicode.com/photos?albumId=1";
            int length;
            int expected;

            // ACT
            length = JSONAPI.ReadAlbum(url).Length;
            expected = 50;

            // ASSERT
            Assert.Equal(length, expected);
        }

        [Fact]
        public void TestReadAlbumEmpty()
        {
            // ARRANGE
            string url = "https://jsonplaceholder.typicode.com/photos?albumId=101";
            int length;
            int expected;

            // ACT
            length = JSONAPI.ReadAlbum(url).Length;
            expected = 0;

            // ASSERT
            Assert.Equal(length, expected);
        }

        [Fact]
        public void TestReadAlbumFail()
        {
            // ARRANGE
            string url = "https://jsonplaceholder.typicode.com/photosalbumId=1";

            // ACT
            Photo[] album  = JSONAPI.ReadAlbum(url);

            // ASSERT
            Assert.Null(album);
        }

        [Fact]
        public void TestReadAlbumContinuity()
        {
            // ARRANGE
            string url = "https://jsonplaceholder.typicode.com/photos?albumId=1";
            int expectedId;
            string expectedTitle;

            // ACT
            Photo[] photos = JSONAPI.ReadAlbum(url);
            expectedId = 1;
            expectedTitle = "accusamus beatae ad facilis cum similique qui sunt";

            // ASSERT
            Assert.Equal(photos[0].id, expectedId);
            Assert.Equal(photos[0].title, expectedTitle);
        }
    }
}
