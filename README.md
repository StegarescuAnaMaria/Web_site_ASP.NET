# Web_site_ASP.NET
A small Starset fan-site created using ASP.NET MVC

Note: Not all files could be included (e.g. libraries and the database).

This is a small project made in ASP.NET MVC (Visual Studio). 
![](gif/1.gif)
![](gif/2.gif)

I have implemented external login with FaceBook, and I made it require both the first name and e-mail. A hello message will appear with the current username (chosen 
on register or the first name requested from FB) in the top right corner. 
The image and video gallery pages let only the admin make changes. The admin can delete, update (replace the current image/video with another) or add images and videos. 
The gallery rearranges itself when changes are made. 
There is also a chat, but it's only public. 
![](gif/3.gif)

The admin can add an image from their computer, and it will automatically be saved in the "ImagesGallery" directory. The full path to the image is saved to the database.
Note: My screen capture recording doesn't show how I chose the file from my computer for some reason. 
The difference with the videos is that they are not being saved anywhere. The videos are embedded directly from youtube. 
![](gif/4.gif)
When the admin inputs the URL, the video id is extracted from the url and then we use the id to get the thumbnail in maximum resolution by sending the request to YT. 
We get a link to the image that is saved to the database with the URL and video id. The video gallery displays images, with a "play button" icon centered on them. 
The cursor changes upon hovering on the play button, and the video is launched on click. The pages are responsive, so the button stays centered on changing the size and shape of the screen. 
![](gif/5.gif)
![](gif/4.5.gif)
The messages from the chat here were sent from different accounts from incognito tabs, though the tabs don't show on the recording.
![](gif/6.gif)

Users can also view all other users displayed on in a table, they can send friend request, approve them or decline, and delete friends from the list. There is a separate list of users, friends and friend requests. Anonymous users cannot view those lists. When an anonymous user clicks on the chat page, they are directed to the log in page. 
![](gif/7.gif)
![](gif/8.gif)


