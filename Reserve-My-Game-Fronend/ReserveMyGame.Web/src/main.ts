import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { provideHttpClient } from '@angular/common/http';


  bootstrapApplication(AppComponent, {
    ...appConfig, // Spread existing app configuration
    providers: [
      provideHttpClient(), // Registers HttpClient globally
      ...(appConfig.providers || []) // Ensure existing providers are included
    ]
  }).catch((err) => console.error(err));
