[![Build status](https://ci.appveyor.com/api/projects/status/fxs3hmfgjsslguas)](https://ci.appveyor.com/project/lontivero/peer2net)

[![NuGet version](https://badge.fury.io/nu/peer2net.png)](http://badge.fury.io/nu/peer2net)

Peer2Net
======

Peer2Net is a lightweight and easy-to-use class library to develop peer-to-peer applications in .NET and Mono. 
Programming with sockets, and using tcp as communication protocol in particular, introduces some complexites which can be abstracted away.


Goals
-----
The main goal is to simplify communication amoung computers abstracting away most of the complexities developers find when develop with sockets, providing a clean and easy interface to connect, disconnect, send  and receive data to/from peers. 


Example
--------
A simple Echo service that once received a message, sends it back.

```c#
var listener = new Listener(9988);
var comManager = new CommunicationManager(_listener);

comManager.PeerDataReceived += (s, e)=>  comManager.Send(e.Peer.EndPoint, e.Data);

listener.Start();
```

API
------
The main functionality is available trought the CommunicationManager class and its four methods: Connect, Disconnect, Send and Receive.

![alt tag](http://geeks.ms/cfs-file.ashx/__key/CommunityServer.Blogs.Components.WeblogFiles/lontivero/CommunicationManager_5F00_4FE194D4.png)


Points of interest
-------------------

Other goals are:
* Avoid multi-threading. It uses a single thread approach to handle all the asynchronous operations and queue the communications' results in a independent queue for processing.
* Reduce memory fragmentation: It implements its own buffer allocation mecanism to help the garbage collector to 
deal with pinned memory.
* Low-memory usage. Internally, pooled objects and pre-allocated buffers are used to reduce the memory requirements.
* Low-grained bandwidth control. It allows to control the individual peer's upload and download rates.

Development
-----------
Peer2Net is developed by [Lucas Ontivero](http://geeks.ms/blogs/lontivero) ([@lontivero](http://twitter.com/lontivero)). You are welcome to contribute code. You can send code both as a patch or a GitHub pull request.

Note that Peer2Net is still very much work in progress. 
