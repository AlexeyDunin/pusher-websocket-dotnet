﻿using System;

namespace PusherClient
{
    /// <summary>
    /// This exception is raised when when a channel subscription error is detected.
    /// </summary>
    public class ChannelException : PusherException
    {
        /// <summary>
        /// Creates a new instance of a <see cref="ChannelException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="code">The Pusher error code.</param>
        /// <param name="channelName">The name of the channel.</param>
        /// <param name="socketId">The socket ID used in the authorization attempt.</param>
        public ChannelException(string message, ErrorCodes code, string channelName, string socketId)
            : base(message, code)
        {
            this.ChannelName = channelName;
            this.SocketID = socketId;
        }

        /// <summary>
        /// Creates a new instance of a <see cref="ChannelException"/> class.
        /// </summary>
        /// <param name="code">The Pusher error code.</param>
        /// <param name="channelName">The name of the channel.</param>
        /// <param name="socketId">The socket ID used in the authorization attempt.</param>
        /// <param name="innerException">The exception that caused the current exception.</param>
        public ChannelException(ErrorCodes code, string channelName, string socketId, Exception innerException)
            : base($"Unexpected error subscribing to channel {channelName}:{Environment.NewLine}{innerException.Message}", code, innerException)
        {
            this.ChannelName = channelName;
            this.SocketID = socketId;
        }

        /// <summary>
        /// Creates a new instance of a <see cref="ChannelException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="code">The Pusher error code.</param>
        /// <param name="channelName">The name of the channel.</param>
        /// <param name="socketId">The socket ID used in the authorization attempt.</param>
        /// <param name="innerException">The exception that caused the current exception.</param>
        public ChannelException(string message, ErrorCodes code, string channelName, string socketId, Exception innerException)
            : base(message, code, innerException)
        {
            this.ChannelName = channelName;
            this.SocketID = socketId;
        }

        /// <summary>
        /// Gets the name of the channel for which the exception occured.
        /// </summary>
        public string ChannelName { get; private set; }

        /// <summary>
        /// Gets or sets the channel's message data if available.
        /// </summary>
        public string MessageData { get; set; }

        /// <summary>
        /// Gets the socket ID used in the authorization attempt.
        /// </summary>
        public string SocketID { get; private set; }

        /// <summary>
        /// Gets or sets the <see cref="Channel"/> that errored. Note that this value can be null.
        /// </summary>
        public Channel Channel { get; set; }
    }
}
