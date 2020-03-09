using System;
using System.Collections.Generic;
using System.Text;

namespace CanBusMonitor.PoC.Parsing
{
    class ISO_TP
    {
        /**
        * @brief Struct containing the data for linking an application to a CAN instance.
        * The data stored in this struct is used internally and may be used by software programs
        * using this library.
        */
        public unsafe struct IsoTpLink
        {
            /* sender paramters */
            uint send_arbitration_id; /* used to reply consecutive frame */
            /* message buffer */
            Byte* send_buffer;
            ushort send_buf_size;
            ushort send_size;
            ushort send_offset;
            /* multi-frame flags */
            Byte send_sn;
            ushort send_bs_remain; /* Remaining block size */
            Byte send_st_min;    /* Separation Time between consecutive frames, unit millis */
            Byte send_wtf_count; /* Maximum number of FC.Wait frame transmissions  */
            uint send_timer_st;  /* Last time send consecutive frame */
            uint send_timer_bs;  /* Time until reception of the next FlowControl N_PDU
                                                   start at sending FF, CF, receive FC
                                                   end at receive FC */
            int send_protocol_result;
            Byte send_status;

            /* receiver paramters */
            uint receive_arbitration_id;
            /* message buffer */
            Byte* receive_buffer;
            ushort receive_buf_size;
            ushort receive_size;
            ushort receive_offset;
            /* multi-frame control */
            Byte receive_sn;
            Byte receive_bs_count; /* Maximum number of FC.Wait frame transmissions  */
            uint receive_timer_cr; /* Time until transmission of the next ConsecutiveFrame N_PDU
                                                     start at sending FC, receive CF 
                                                     end at receive FC */
            int receive_protocol_result;
            Byte receive_status;
        }

        ///////////////////////////////////////////////////////
        ///                 STATIC FUNCTIONS                ///
        ///////////////////////////////////////////////////////
        
        /* st_min to microsecond */
        public static Byte isotp_ms_to_st_min(Byte ms)
        {
            Byte st_min;

            st_min = ms;
            if (st_min > 0x7F)
            {
                st_min = 0x7F;
            }

            return st_min;
        }

        /* st_min to msec  */
        public static Byte isotp_st_min_to_ms(Byte st_min)
        {
            Byte ms;

            if (st_min >= 0xF1 && st_min <= 0xF9)
            {
                ms = 1;
            }
            else if (st_min <= 0x7F)
            {
                ms = st_min;
            }
            else
            {
                ms = 0;
            }

            return ms;
        }
    }
}
