/* ========================================================================
 * jQuery Geocoder
 * ========================================================================
 * Copyright 2014-2016 Daniel Stainback
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ======================================================================== */

+function ($) {
    "use strict";

    var request;

    var getRequest = function () {
        if (window.ActiveXObject)
            return new ActiveXObject('Microsoft.XMLHTTP');
        else if (window.XMLHttpRequest)
            return new XMLHttpRequest();
        return false;
    };

    var ajax = function (param, callbacks) {
        var uid = Date.now(),
            url = 'https://maps.googleapis.com/maps/api/geocode/json?' + param + '&sensor=false&callback=jQuery' + uid

        // Abort old request
        if (request && typeof request.abort === 'function') request.abort();

        request = getRequest();

        if (request) {
            request.onreadystatechange = function (object) {
                if (request.readyState == 4) {
                    if (request.status === 200) {
                        if (callbacks['success']) {
                            callbacks['success']($.parseJSON(request.responseText));
                        }
                    }
                    else if (callbacks['error']) {
                        callbacks['error']();
                    }
                }
            };
            request.open('GET', url, true);
            request.send();
        }
    };

    /*
     * Parse points from Google
     */
    var parsePoints = function (data) {
        var points = [];

        $(data.results).each(function (i, item) {

            var point = {
                //formatted: '',
                formatted: item.formatted_address,
                address: '',
                street_number: '',
                street_address: '',
                city: '',
                state: '',
                postal_code: '',
                state_code: '',
                cc: '',
                lat: item.geometry.location.lat,
                lng: item.geometry.location.lng
            };

            // Parse that shit
            $(item.address_components).each(function () {
                switch (this.types[0]) {
                    case 'street_number':
                        point.street_number = this.long_name;
                        break;
                    case 'postal_code':
                        point.postal_code = this.short_name;
                        break;
                    case 'route':
                        point.street_address = this.long_name;
                        break;
                    case 'administrative_area_level_1':
                        point.state = this.long_name;
                        point.state_code = this.short_name;
                        break;
                    case 'locality':
                        point.city = this.long_name;
                        break;
                    case 'country':
                        point.cc = this.short_name;
                        break;
                }
            });

            // Add street address with number
            if (point.street_number) {
                point.formatted = point.street_number + ' ' + point.street_address + ', ' +
                    point.city + ', ' + point.state_code;

                point.address = point.street_number + ' ' + point.street_address;
            }
            else {
                point.formatted = point.city + ', ' + point.state_code;
            }

            if (point.city && point.state_code) {
                points.push(point);
            }
        });

        return points;
    };


    // PLUGIN DEFINITION
    // ==================

    $.geo = {
        geocode: function (param, options) {
            ajax('address=' + param, {
                success: function (data) {
                    if (options['success']) options['success'](parsePoints(data));
                    if (options['complete']) options['complete']();
                },
                error: function () {
                    if (options['error']) options['error']();
                    if (options['complete']) options['complete']();
                }
            });
        },

        reverseGeocode: function (point, options) {
            ajax('latlng=' + point.lat + ',' + point.lng, {
                success: function (data) {
                    if (options['success']) options['success'](parsePoints(data));
                    if (options['complete']) options['complete']();
                },
                error: function () {
                    if (options['error']) options['error']();
                    if (options['complete']) options['complete']();
                }
            });
        }
    }
}(window.jQuery);
