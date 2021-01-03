/* Name: requests.h
 * Project: GeigerMuellerCounter
 * Author: Phillip Durdaut
 * Based on "custom-class, a basic USB example" by Christian Starkjohann
 * Creation Date: 2008-04-10
 * Tabsize: 4
 * Copyright: (c) 2008 by OBJECTIVE DEVELOPMENT Software GmbH
 * License: GNU GPL v2 (see License.txt), GNU GPL v3 or proprietary (CommercialLicense.txt)
 */

/* This header is shared between the firmware and the host software. It
 * defines the USB request numbers (and optionally data types) used to
 * communicate between the host and the device.
 */

#ifndef REQUESTS_H
#define REQUESTS_H

/* Reset counts */
#define CUSTOM_RQ_RESET_COUNTS	0

/* Get counts */
#define CUSTOM_RQ_GET_COUNTS	1

#endif /* REQUESTS_H */
