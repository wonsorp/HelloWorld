﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Rest.Model.Message
{
    public class MessageDto 
    {
        public int StorageType { get; set; }
        public int MessageId { get; set; }
        public string Message { get; set; }
    }
}
