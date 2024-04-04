# Vision Pro Unity Quick Start with Agora SDK

## Sample Scene

### Simulator
<img width="1048" alt="Screenshot simulator" src="https://github.com/icywind/HelloAgoraVision/assets/1261195/def63eca-ac8a-4655-a921-8099ce172895">

### VisionPro device
<img width="1048" alt="Screenshot simulator"  src="https://github.com/icywind/HelloAgoraVision/assets/1261195/916ea8b2-8e52-4489-a1f0-8e31025b2035">

## Developer Environment Prerequisites
-   Mac computer with silicon CPU (M1 or above)    
-   XCode    
-   Apple Developer membership
-   Unity 2022.3 LTS  
-   Unity Developer license - Pro/Plus/Enterprise
-   Agora Developer account
-   Agora Video SDK that includes VisionOS plugin
## Quick Start

This section shows you how to prepare, build, and run the sample application.

### Obtain an App ID
To build and run the sample application, get an App ID:

1. Create a developer account at [agora.io](https://dashboard.agora.io/signin/). Once you finish the signup process, you will be redirected to the Dashboard.

2. Navigate in Agora Console on the left to **Projects** > **More** > **Create** > **Create New Project**.

3. Save the **App ID** from the Dashboard for later use.
  
### Project Description

#### Create XCode Project
1. Clone this repo and open the project from this folder
2. Set up Unity environment for the VisionOS 
3. Download the latest SDK, temporarily a preview in the Release section
4. Open TestAgoraVP scene
5. Fill in App ID and Channel Name.  
![VP-agoramanager](https://github.com/icywind/HelloAgoraVision/assets/1261195/43b944ba-bd88-4d0e-8359-cb1d84fbcb92)

6. Make sure if your AppID has token or not.  Things won't work if you don't supply a token if your AppID requires one.  We recommend use an AppID for testing first before applying token logic.
7. Use [the Web Demo](https://webdemo.agora.io/basicVideoCall/index.html) as a second user to test the RTC call.
8. Build the project.  For Simulator, make sure the Target SDK is set to "**Simulator SDK**"
  ![vp-similatorSDK](https://github.com/icywind/HelloAgoraVision/assets/1261195/667b91a9-48f3-479c-b65b-ed50543891a8)
9. (Temporarily) with the Preview SDK, remember remove the ARM64 folder from the Framework or you will get lots of duplicate symbol error message.![vp-remove-arm64](https://github.com/icywind/HelloAgoraVision/assets/1261195/9db941b4-b85c-4354-9ac4-c906a2d042f3)
10. Build and Run the project; you should see the screen similar to the first screenshot of this README file
11. Join the channel using the WebDemo and you should have enabled video chat between the two users
12. If everything works well in the Simulator, you should have high confidence that the project works on the device.  Set the Target SDK to "**Device SDK**" on Unity Editor.
![VP-devicebuild](https://github.com/icywind/HelloAgoraVision/assets/1261195/bbc1e63c-8461-4b6a-b6c1-a27ca8cdd3e6)
 13. Make a build again, and follow the usual build process to build for the target device
 14. After deploying, you should see similar set up like the second screenshot picture.
  
## License

The MIT License (MIT).
