package oseg.namsor_examples

import app.namsor.client.infrastructure.*
import app.namsor.client.apis.*
import app.namsor.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map

class PhoneCodeExample
{
    fun phoneCode()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        try
        {
            val response = SocialApi().phoneCode(
                firstName = "Jamini",
                lastName = "Roy",
                phoneNumber = "09804201420",
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling SocialApi#phoneCode")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling SocialApi#phoneCode")
            e.printStackTrace()
        }
    }
}
