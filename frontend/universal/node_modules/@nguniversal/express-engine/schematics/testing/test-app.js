/**
 * @license
 * Copyright Google LLC All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://angular.io/license
 */
(function (factory) {
    if (typeof module === "object" && typeof module.exports === "object") {
        var v = factory(require, exports);
        if (v !== undefined) module.exports = v;
    }
    else if (typeof define === "function" && define.amd) {
        define("@nguniversal/express-engine/schematics/testing/test-app", ["require", "exports", "@angular-devkit/schematics/testing", "path", "rxjs/operators"], factory);
    }
})(function (require, exports) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    const testing_1 = require("@angular-devkit/schematics/testing");
    const path_1 = require("path");
    const operators_1 = require("rxjs/operators");
    /** Path to the collection file for the NgUniversal schematics */
    exports.collectionPath = path_1.join(__dirname, '..', 'collection.json');
    /** Create a base app used for testing. */
    function createTestApp(appOptions = {}) {
        const baseRunner = new testing_1.SchematicTestRunner('universal-schematics', exports.collectionPath);
        return baseRunner
            .runExternalSchematicAsync('@schematics/angular', 'workspace', {
            name: 'workspace',
            version: '6.0.0',
            newProjectRoot: 'projects',
        })
            .pipe(operators_1.switchMap(workspaceTree => baseRunner.runExternalSchematicAsync('@schematics/angular', 'application', Object.assign({}, appOptions, { name: 'bar' }), workspaceTree)));
    }
    exports.createTestApp = createTestApp;
});
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoidGVzdC1hcHAuanMiLCJzb3VyY2VSb290IjoiIiwic291cmNlcyI6WyIuLi8uLi8uLi8uLi8uLi8uLi8uLi9tb2R1bGVzL2V4cHJlc3MtZW5naW5lL3NjaGVtYXRpY3MvdGVzdGluZy90ZXN0LWFwcC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTs7Ozs7O0dBTUc7Ozs7Ozs7Ozs7OztJQUVILGdFQUFxRjtJQUNyRiwrQkFBMEI7SUFFMUIsOENBQXlDO0lBRXpDLGlFQUFpRTtJQUNwRCxRQUFBLGNBQWMsR0FBRyxXQUFJLENBQUMsU0FBUyxFQUFFLElBQUksRUFBRSxpQkFBaUIsQ0FBQyxDQUFDO0lBRXZFLDBDQUEwQztJQUMxQyxTQUFnQixhQUFhLENBQUMsVUFBVSxHQUFHLEVBQUU7UUFDM0MsTUFBTSxVQUFVLEdBQ1osSUFBSSw2QkFBbUIsQ0FBQyxzQkFBc0IsRUFBRSxzQkFBYyxDQUFDLENBQUM7UUFFcEUsT0FBTyxVQUFVO2FBQ1oseUJBQXlCLENBQUMscUJBQXFCLEVBQUUsV0FBVyxFQUFFO1lBQzdELElBQUksRUFBRSxXQUFXO1lBQ2pCLE9BQU8sRUFBRSxPQUFPO1lBQ2hCLGNBQWMsRUFBRSxVQUFVO1NBQzNCLENBQUM7YUFDRCxJQUFJLENBQ0QscUJBQVMsQ0FBQyxhQUFhLENBQUMsRUFBRSxDQUFDLFVBQVUsQ0FBQyx5QkFBeUIsQ0FDdkQscUJBQXFCLEVBQUUsYUFBYSxvQkFDaEMsVUFBVSxJQUFFLElBQUksRUFBRSxLQUFLLEtBQUcsYUFBYSxDQUFDLENBQUMsQ0FDeEQsQ0FBQztJQUNSLENBQUM7SUFmRCxzQ0FlQyIsInNvdXJjZXNDb250ZW50IjpbIi8qKlxuICogQGxpY2Vuc2VcbiAqIENvcHlyaWdodCBHb29nbGUgTExDIEFsbCBSaWdodHMgUmVzZXJ2ZWQuXG4gKlxuICogVXNlIG9mIHRoaXMgc291cmNlIGNvZGUgaXMgZ292ZXJuZWQgYnkgYW4gTUlULXN0eWxlIGxpY2Vuc2UgdGhhdCBjYW4gYmVcbiAqIGZvdW5kIGluIHRoZSBMSUNFTlNFIGZpbGUgYXQgaHR0cHM6Ly9hbmd1bGFyLmlvL2xpY2Vuc2VcbiAqL1xuXG5pbXBvcnQge1NjaGVtYXRpY1Rlc3RSdW5uZXIsIFVuaXRUZXN0VHJlZX0gZnJvbSAnQGFuZ3VsYXItZGV2a2l0L3NjaGVtYXRpY3MvdGVzdGluZyc7XG5pbXBvcnQge2pvaW59IGZyb20gJ3BhdGgnO1xuaW1wb3J0IHtPYnNlcnZhYmxlfSBmcm9tICdyeGpzJztcbmltcG9ydCB7c3dpdGNoTWFwfSBmcm9tICdyeGpzL29wZXJhdG9ycyc7XG5cbi8qKiBQYXRoIHRvIHRoZSBjb2xsZWN0aW9uIGZpbGUgZm9yIHRoZSBOZ1VuaXZlcnNhbCBzY2hlbWF0aWNzICovXG5leHBvcnQgY29uc3QgY29sbGVjdGlvblBhdGggPSBqb2luKF9fZGlybmFtZSwgJy4uJywgJ2NvbGxlY3Rpb24uanNvbicpO1xuXG4vKiogQ3JlYXRlIGEgYmFzZSBhcHAgdXNlZCBmb3IgdGVzdGluZy4gKi9cbmV4cG9ydCBmdW5jdGlvbiBjcmVhdGVUZXN0QXBwKGFwcE9wdGlvbnMgPSB7fSk6IE9ic2VydmFibGU8VW5pdFRlc3RUcmVlPiB7XG4gIGNvbnN0IGJhc2VSdW5uZXIgPVxuICAgICAgbmV3IFNjaGVtYXRpY1Rlc3RSdW5uZXIoJ3VuaXZlcnNhbC1zY2hlbWF0aWNzJywgY29sbGVjdGlvblBhdGgpO1xuXG4gIHJldHVybiBiYXNlUnVubmVyXG4gICAgICAucnVuRXh0ZXJuYWxTY2hlbWF0aWNBc3luYygnQHNjaGVtYXRpY3MvYW5ndWxhcicsICd3b3Jrc3BhY2UnLCB7XG4gICAgICAgIG5hbWU6ICd3b3Jrc3BhY2UnLFxuICAgICAgICB2ZXJzaW9uOiAnNi4wLjAnLFxuICAgICAgICBuZXdQcm9qZWN0Um9vdDogJ3Byb2plY3RzJyxcbiAgICAgIH0pXG4gICAgICAucGlwZShcbiAgICAgICAgICBzd2l0Y2hNYXAod29ya3NwYWNlVHJlZSA9PiBiYXNlUnVubmVyLnJ1bkV4dGVybmFsU2NoZW1hdGljQXN5bmMoXG4gICAgICAgICAgICAgICAgICAnQHNjaGVtYXRpY3MvYW5ndWxhcicsICdhcHBsaWNhdGlvbicsXG4gICAgICAgICAgICAgICAgICB7Li4uYXBwT3B0aW9ucywgbmFtZTogJ2Jhcid9LCB3b3Jrc3BhY2VUcmVlKSksXG4gICAgICApO1xufVxuIl19