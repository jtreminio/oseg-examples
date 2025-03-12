package oseg.chatwoot_examples

import com.chatwoot.client.infrastructure.*
import com.chatwoot.client.apis.*
import com.chatwoot.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class CreateAnIntegrationHookExample
{
    fun createAnIntegrationHook()
    {
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"
        // ApiClient.apiKey["agentBotApiKey"] = "AGENT_BOT_API_KEY"
        // ApiClient.apiKey["platformAppApiKey"] = "PLATFORM_APP_API_KEY"

        val integrationsHookCreatePayload = IntegrationsHookCreatePayload(
            appId = null,
            inboxId = null,
        )

        try
        {
            val response = IntegrationsApi().createAnIntegrationHook(
                accountId = null,
                _data = integrationsHookCreatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling IntegrationsApi#createAnIntegrationHook")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling IntegrationsApi#createAnIntegrationHook")
            e.printStackTrace()
        }
    }
}
