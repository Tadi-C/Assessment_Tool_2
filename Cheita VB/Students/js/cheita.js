// This function creates an instance of the YouTube player
function onYouTubeIframeAPIReady() {
    // Replace 'VIDEO_ID' with the actual ID of the YouTube video you want to embed
    var videoId = '5MLZsO7Hyzs;

    // Create a new instance of the YouTube player
    var player = new YT.Player('player', {
        height: '315',
        width: '560',
        videoId: videoId
    });
}