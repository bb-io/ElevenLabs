# Blackbird.io ElevenLabs  
  
Blackbird is the new automation backbone for the language technology industry. Blackbird provides enterprise-scale automation and orchestration with a simple no-code/low-code platform. Blackbird enables ambitious organizations to identify, vet and automate as many processes as possible. Not just localization workflows, but any business and IT process. This repository represents an application that is deployable on Blackbird and usable inside the workflow editor.  
  
## Introduction  
  
<!-- begin docs -->  
  
ElevenLabs is a state-of-the-art speech synthesis and conversion platform that offers advanced tools for converting text to speech and speech to speech. It provides high-quality voice generation capabilities, enabling users to create realistic and customizable voice outputs for various applications, including content creation, accessibility, and more.
  
## Connecting

1.  In Blackbird, navigate to 'Apps' and search for ElevenLabs.
2.  Click _Add Connection_.
3.  Name your connection for future reference e.g. 'My ElevenLabs connection'.
4.  In ElevenLabs, go to `My account -> Profile + API key`.
5.  Copy the  API key and paste it into the appropriate field in Blackbird.
6.  Click _Connect_.
7.  Confirm that the connection has appeared and the status is _Connected_.
  
## Actions  
  
### Speech Conversion

-   **Convert speech to speech** Converts provided speech to a speech with selected settings.
-   **Convert text to speech** Converts provided text to a speech with selected settings.
  
### Audio

- **Generate sound** Generates a sound from the provided text.
- **Isolate audio** Removes background noise from audio.

## Dubbing

- **Create a dub** Creates a dub of a video or audio file.
- **Get dubbing details** Gets details of dubbing.
- **Download dubbed transcript** Downloads dubbed transcript in srt or vtt format.
- **Download dubbed file** Downloads the dubbed audio or video file.

## Example  
  
The following example shows how a bird can be setup so that anytime a Slack app is mentioned, the message is prompted via OpenAI, after that it is turned into speech via ElevenLabs and is sent back to Slack as a response.

![Sample Bird](https://github.com/bb-io/ElevenLabs/assets/137277669/26345195-1715-4719-92a6-f41bd6bf60ac)
  
## Feedback  
  
Do you want to use this app or do you have feedback on our implementation? Reach out to us using the [established channels](https://www.blackbird.io/) or create an issue.  
  
<!-- end docs -->
